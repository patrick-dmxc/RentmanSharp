using System.Collections.Concurrent;

namespace RentmanSharp
{
    public static class HttpClientTools
    {
        private static ulong queueID = 0;
        private static Queue<Tuple<ulong, HttpClient, HttpRequestMessage>> requestQueue = new Queue<Tuple<ulong, HttpClient, HttpRequestMessage>>();
        private static List<Tuple<ulong, HttpResponseMessage>> responseQueue = new List<Tuple<ulong, HttpResponseMessage>>();
        private static Thread QueueThread = null;
        private static object lockObject = new object();
        public static async Task<HttpResponseMessage> SendAsyncLimited(this HttpClient httpClient, HttpRequestMessage request)
        {
            var req = new Tuple<ulong, HttpClient, HttpRequestMessage>(queueID++, httpClient, request);
            try
            {
                lock (requestQueue)
                    requestQueue.Enqueue(req);

                runThread();
                for (byte b = 0; b < 100; b++)
                {
                    await Task.Delay(20);
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
            }
            throw new Exception("Cold not receive any response");
        }

        private static void runThread()
        {
            if (QueueThread != null)
                return;

            lock (lockObject)
            {
                QueueThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(20);
                        if (requestQueue.Count == 0)
                            continue;

                        Task.Run(async () =>
                        {
                            try
                            {
                                Tuple<ulong, HttpClient, HttpRequestMessage> req = null;
                                lock (requestQueue)
                                    if (requestQueue.Count != 0)
                                        req = requestQueue.Dequeue();

                                if (req != null)
                                {
                                    var res = await req.Item2.SendAsync(req.Item3);

                                    lock (responseQueue)
                                        responseQueue.Add(new Tuple<ulong, HttpResponseMessage>(req.Item1, res));
                                }
                            }
                            catch (Exception e)
                            {
                            }
                        });
                    }
                });
                QueueThread.Name = "HTTPClientThread";
                QueueThread.IsBackground = true;
                QueueThread.Priority = ThreadPriority.BelowNormal;
                QueueThread.Start();
            }
        }
    }
}
