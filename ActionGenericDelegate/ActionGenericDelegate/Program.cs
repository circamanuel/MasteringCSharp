namespace ActionGenericDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = () =>
            {
                Console.WriteLine("Hello World");
            };

            action();

            // if only one parameter no (x) is needed
            Action<int> numPrint = x =>
            {
                Console.WriteLine(x);
            };

            numPrint(10);

            Action<float, float, float> sum = (x, y, z) =>
            {
                Console.WriteLine($"{x} {y} {z}");
            };
            sum(1, 2, 3);
        }
    }
}
