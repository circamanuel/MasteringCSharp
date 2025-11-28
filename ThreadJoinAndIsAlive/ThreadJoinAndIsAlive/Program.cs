namespace ThreadJoinAndIsAlive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread started");

            //Thread oppens a new Process for the funtion Thread1Function
            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);
            thread1.Start();
            thread2.Start();

            // Stops Calling thread until this Process ended or specified 1 second
 
            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread1Function done");
            }
            else
            {
                Console.WriteLine("Thread1Function wasn't done within 1 sec");
            }

            thread2.Join();
            Console.WriteLine("Thread2Function done");
            
            // We loose 1 second until here so ony 7 cycles
            for (int i = 0; i<10; i++)
            {
            if (thread1.IsAlive)
            {
                Console.WriteLine("thread1 is still doing stuff");
                    Thread.Sleep(300);
            }
            else
            {
                Console.WriteLine("Thread1 compleded");
            }

                
            }
                Console.WriteLine("Main Thread ended");
        }


        public static void Thread1Function()
        {
            Console.WriteLine("Threa1Function started");
            Thread.Sleep(3000);
            Console.WriteLine("Thread1Function coming back to caller");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }
    }
}
