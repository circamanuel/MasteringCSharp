namespace FuncGenericDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // last parameter is allways the return type
            Func<int, int, string> sum = (x, y) =>
            {
                return (x + y).ToString();
            };

            Console.WriteLine(sum(3,5));
        }
    }
}
