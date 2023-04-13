namespace RentmanSharp
{
    public readonly struct CacheOptions
    {
        private static ILogger? _logger;
        private static ILogger logger
        {
            get
            {
                if (_logger == null)
                    _logger = ApplicationLogging.LoggerFactory.CreateLogger(typeof(CacheOptions));

                return _logger;
            }
        }

        public static CacheOptions Disabled = new CacheOptions();
        public static CacheOptions Default = new CacheOptions(new TimeOnly(0, 0, 30), new TimeOnly(8, 0), new TimeOnly(0, 30));
        public readonly bool Enabled = false;
        public readonly TimeOnly Delay = TimeOnly.MinValue;
        public readonly TimeOnly CroneInterval = TimeOnly.MinValue;
        public readonly TimeOnly IncrementInterval = TimeOnly.MinValue;
        public readonly byte ParallelLimit = 5;
        public readonly Type[] CachedEndpoints = new Type[0];
        public CacheOptions() 
        {
        }
        public CacheOptions(TimeOnly delay, TimeOnly croneInterval, TimeOnly incrementInterval, byte parallelLimit = 3, params Type[] cachedEndpoints) : this()
        {
            Enabled = true;
            Delay = delay;
            CroneInterval = croneInterval;
            IncrementInterval = incrementInterval;
            ParallelLimit = parallelLimit;
            try
            {
                if (cachedEndpoints == null || cachedEndpoints.Length == 0)
                    return;
                CachedEndpoints = cachedEndpoints;
            }
            catch(Exception e)
            {
                logger.LogDebug(e, string.Empty);
            }
        }
    }
}