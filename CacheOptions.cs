namespace RentmanSharp
{
    public readonly struct CacheOptions
    {
        public static CacheOptions Disabled = new CacheOptions();
        public static CacheOptions Default = new CacheOptions(new TimeOnly(0, 0, 30), new TimeOnly(8, 0), new TimeOnly(0, 30));
        public readonly bool Enabled = false;
        public readonly TimeOnly Delay = TimeOnly.MinValue;
        public readonly TimeOnly CroneInterval = TimeOnly.MinValue;
        public readonly TimeOnly IncrementInterval = TimeOnly.MinValue;
        public CacheOptions() 
        {
        }
        public CacheOptions(TimeOnly delay, TimeOnly croneInterval, TimeOnly incrementInterval) : this()
        {
            Enabled = true;
            Delay = delay;
            CroneInterval = croneInterval;
            IncrementInterval = incrementInterval;
        }
    }
}