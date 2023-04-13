namespace RentmanSharp
{
    public static class HttpClientTools
    {
        private static ILogger? _logger;
        private static ILogger logger
        {
            get
            {
                if (_logger == null)
                    _logger = ApplicationLogging.LoggerFactory.CreateLogger(typeof(HttpClientTools));

                return _logger;
            }
        }

        private static ulong queueID = 0;
        private static Queue<Tuple<ulong, HttpClient, HttpRequestMessage>> requestQueue = new Queue<Tuple<ulong, HttpClient, HttpRequestMessage>>();
        private static List<Tuple<ulong, HttpResponseMessage>> responseQueue = new List<Tuple<ulong, HttpResponseMessage>>();
        private static Thread? QueueThread = null;
        private static object lockObject = new object();


        private static DayOfWeek day = DateTime.Now.DayOfWeek;
        private static int secound = DateTime.Now.Second;

        public static int RequestsWaitForProcess { get; private set; }
        public static int PendingRequests { get; private set; }
        public static ushort RequestsSendSecond { get; private set; }
        public static uint RequestsSendToday { get; private set; }
        public static ulong RequestsSend { get; private set; }


        public static HttpClient CreateHttpCLient()
        {
            return new HttpClient(new HttpClientHandler(), false);
        }

        public static async Task<HttpResponseMessage> SendAsyncLimited(this HttpClient httpClient, HttpRequestMessage request)
        {
            var req = new Tuple<ulong, HttpClient, HttpRequestMessage>(queueID++, httpClient, request);
            try
            {
                logger.LogDebug($"Add Request to Queue: {request.RequestUri} Content: {request.Content}");
                RequestsWaitForProcess++;
                lock (requestQueue)
                    requestQueue.Enqueue(req);

                runThread();
                for (uint b = 0; b < 1000; b++)
                {
                    await Task.Delay(2);
                    lock (responseQueue)
                    {
                        var response = responseQueue.FirstOrDefault(q => q.Item1 == req.Item1);
                        if (response != null)
                        {
                            responseQueue.Remove(response);
                            return response.Item2;
                        }
                    }
                }
            }
            catch(Exception e) 
            {
                logger.LogError(e, string.Empty);
            }
            throw new Exception("Cold not receive any response");
        }

        private static void runThread()
        {
            if (QueueThread != null)
                return;

            lock (lockObject)
            {
                QueueThread = new Thread(async () =>
                {
                    while (true)
                    {
                        var now = DateTime.UtcNow;
                        var newDay = now.DayOfWeek;
                        var newSecond = now.Second;
                        if (day != newDay)
                        {
                            day = newDay;
                            RequestsSendToday = 0;
                        }
                        if (secound != newSecond)
                        {
                            secound = newSecond;
                            RequestsSendSecond = 0;
                        }
                        await Task.Delay(100);
                        if (requestQueue.Count == 0)
                            continue;

                        _ = Task.Run(async () =>
                        {
                            try
                            {
                                Tuple<ulong, HttpClient, HttpRequestMessage>? req = null;
                                lock (requestQueue)
                                    if (requestQueue.Count != 0)
                                    {
                                        req = requestQueue.Dequeue();
                                        RequestsWaitForProcess--;
                                    }

                                if (req != null)
                                {
                                    logger.LogDebug($"Send Request({req.Item1}): {req.Item3.RequestUri} Content: {req.Item3.Content}");
                                    PendingRequests++;
                                    RequestsSend++;
                                    RequestsSendToday++;
                                    RequestsSendSecond++;
                                    try
                                    {
                                        HttpResponseMessage res = await req.Item2.SendAsync(req.Item3);
                                        logger.LogDebug($"Received Response({req.Item1}): StatusCode({res?.StatusCode})");
                                        lock (responseQueue)
                                            responseQueue.Add(new Tuple<ulong, HttpResponseMessage>(req.Item1, res!));
                                    }
                                    finally
                                    {
                                        PendingRequests--;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                logger.LogError(e, string.Empty);
                            }
                        });
                    }
                });
                QueueThread.Name = "HTTPClientThread";
                QueueThread.IsBackground = true;
                QueueThread.Priority = ThreadPriority.Highest;
                QueueThread.Start();
            }
        }
    }
}
