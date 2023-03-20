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

        public void Connect(in string token)
        {

            if (!this.IsInitialized)
                throw new Exception("Not Initialized");

            if (!string.IsNullOrWhiteSpace(Token))
                throw new NotSupportedException($"{nameof(Token)} already defined");
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException($"{nameof(token)} isn't valid");

            _logger?.Log(LogLevel.Information, "Connect");
            Token = token;
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
    }
}