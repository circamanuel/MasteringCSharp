namespace PredicateGenericDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = (x) =>
            {
                return x % 2 == 0;
            };

            List<int> ints = new List<int>() { 1, 2,  3, 4, 5, 6, 7, 8, 9};

            var evenInts = ints.FindAll(isEven);
        }
    }
}
