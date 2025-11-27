using System.Net.Http.Headers;

namespace ConstraintsForGenericMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productOne = new Product();
            var productTwo = new Product();

            // return False -> not the same instance of Product
            var result = Comparer.AreEquals(productOne, productTwo);
            Console.WriteLine(result);
        }

        public class Product()
        {

        }
    }
}
