namespace ThreadsBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Threads Start Parallel but don't excecute at the same time.
            // Threads have different start and end times.
            // Output could be 2, 3, 4, 1

            //new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 1");
            //}).Start();

            //new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 2");
            //}).Start();
            //new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 3");
            //}).Start();
            //new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Thread 4");
            //}).Start();


            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            })
            { IsBackground = false }.Start();

            Enumerable.Range(0, 100).ToList().ForEach(x =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                });
            });

        }
    }
}
