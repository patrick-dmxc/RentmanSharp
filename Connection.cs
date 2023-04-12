using RentmanSharp.Endpoint;

namespace RentmanSharp
{
    public class Connection
    {
        private ILogger<Connection>? _logger = null;
        public string? Token { get; internal set; }
        private static Connection? instance;
        public static Connection Instance
        {
            get
            {
                instance ??= new Connection();
                return instance;
            }
        }
        public bool IsInitialized { get; private set; } = false;

        public CacheOptions CacheOptions
        {
            get;
            private set;
        } = CacheOptions.Disabled;

        private Thread? cacheThread;
        private bool isQueueingData = false;
        private DateTime lastLoop = DateTime.Now;
        private DateTime lastCrone = DateTime.Now;
        private DateTime lastIncrement = DateTime.Now;

        public event EventHandler? CachedNewData = null;
        public event EventHandler? CachedNewDataCrone = null;
        public event EventHandler? CachedNewDataIncrement = null;

        private List<IEndpoint> endpoints { get; } = new();
        public IReadOnlyList<IEndpoint> Endpoints { get => endpoints.AsReadOnly(); }

        private Connection()
        {
        }

        public void Initialize(ILoggerFactory loggerFactory)
        {
            if (this.IsInitialized)
                return;
            ApplicationLogging.LoggerFactory = loggerFactory;
            _logger = ApplicationLogging.CreateLogger<Connection>();
            this.IsInitialized = true;
            _logger?.Log(LogLevel.Information, "Initialized");
            this.findEndPoints();
        }

        public void Connect(in string token, CacheOptions? cacheOptions = null)
        {

            if (!this.IsInitialized)
                throw new Exception("Not Initialized");

            if (!string.IsNullOrWhiteSpace(Token))
                throw new NotSupportedException($"{nameof(Token)} already defined");
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException($"{nameof(token)} isn't valid");

            _logger?.Log(LogLevel.Information, "Connect");
            Token = token;

            if (cacheOptions.HasValue)
            {
                this.CacheOptions = cacheOptions.Value;
                this.startCacheThread();
            }
        }

        private void findEndPoints()
        {
            var type = typeof(IEndpoint);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);

            _logger?.Log(LogLevel.Information, "Search Endpoints");
            foreach (var t in types)
                if (t.GetConstructors().Any(c => c.GetParameters().Length == 0))
                {
                    IEndpoint? instance = (IEndpoint?)Activator.CreateInstance(t);
                    if (instance != null)
                        endpoints.Add(instance);
                }
        }
        public T GetEndpoint<T>() where T : IEndpoint
        {
            return (T)GetEndpoint(typeof(T));
        }
        public IEndpoint GetEndpoint(Type type)
        {
            if (this.endpoints == null)
                throw new NullReferenceException();
            IEndpoint? result = this.endpoints.FirstOrDefault(t => t.GetType() == type);
            if (result != null)
                return result;

            throw new NullReferenceException();
        }

        private void startCacheThread()
        {
            this.cacheThread = new Thread(async () =>
            {
                await Task.Delay(this.CacheOptions.Delay.Millisecond);
                await loopCroneCacheThread();
                while (true)
                {
                    await Task.Delay(100);
                    if (!this.isQueueingData)
                        await this.loopCacheThread();
                }
            });
            this.cacheThread.IsBackground = true;
            this.cacheThread.Priority = ThreadPriority.BelowNormal;
            this.cacheThread.Name = $"Cache-Thread";
            this.cacheThread.Start();
        }
        private async Task loopCacheThread()
        {
            var now = DateTime.Now;
            if ((now - lastCrone).Ticks > CacheOptions.CroneInterval.Ticks)
            {
                lastIncrement = lastCrone = now;
                await loopCroneCacheThread();
            }
            else if ((now - lastIncrement).Ticks > CacheOptions.IncrementInterval.Ticks)
            {
                lastIncrement = now;
                await loopIncrementCacheThread();
            }
            lastLoop = now;
        }
        private async Task loopCroneCacheThread()
        {
            _logger?.LogDebug("Crone Cache");
            List<IEndpoint> pendingCaching = new();
            byte pendingCount = 0;
            var _endpoints = endpoints.ToArray();
            if (CacheOptions.CachedEndpoints.Length != 0)
                _endpoints = endpoints.Where(ep => CacheOptions.CachedEndpoints.Any(cep => cep == ep.GetType())).ToArray();
            foreach (var endpoint in _endpoints)
            {
                while (pendingCount >= CacheOptions.ParallelLimit)
                    await Task.Delay(10);

                lock (pendingCaching)
                {
                    pendingCount++;
                    pendingCaching.Add(endpoint);
                }
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await endpoint.GetCollectionEntity();

                        lock (pendingCaching)
                        {
                            pendingCaching.Remove(endpoint);
                            pendingCount--;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(string.Empty, ex);
                    }
                    finally
                    {
                        lock (pendingCaching)
                        {
                            pendingCaching.Remove(endpoint);
                            pendingCount--;
                        }
                    }
                });
            }

            while (pendingCount > 0)
                await Task.Delay(10);

            CachedNewData?.Invoke(this, EventArgs.Empty);
            CachedNewDataCrone?.Invoke(this, EventArgs.Empty);
        }
        private async Task loopIncrementCacheThread()
        {
            _logger?.LogDebug("Increment Cache");
            List<IEndpoint> pendingCaching = new();
            byte pendingCount = 0;
            var _endpoints = endpoints.ToArray();
            if (CacheOptions.CachedEndpoints.Length != 0)
                _endpoints = endpoints.Where(ep => CacheOptions.CachedEndpoints.Any(cep => cep == ep.GetType())).ToArray();
            foreach (var endpoint in _endpoints)
            {
                while (pendingCount >= CacheOptions.ParallelLimit)
                    await Task.Delay(10);

                lock (pendingCaching)
                {
                    pendingCount++;
                    pendingCaching.Add(endpoint);
                }
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await endpoint.GetCollectionEntity(Filter.IncrementFilter);
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(string.Empty, ex);
                    }
                    finally
                    {
                        lock (pendingCaching)
                        {
                            pendingCaching.Remove(endpoint);
                            pendingCount--;
                        }
                    }
                });
            }

            while (pendingCount > 0)
                await Task.Delay(10);

            CachedNewData?.Invoke(this, EventArgs.Empty);
            CachedNewDataIncrement?.Invoke(this, EventArgs.Empty);
        }
    }
}