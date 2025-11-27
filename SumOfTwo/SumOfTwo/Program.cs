namespace SumOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {

           int value = SumOfTwo([ 1, 1, 1, 2, 3, 4, 5, 2 ],2 );
            Console.WriteLine(value);
        }

        public static int SumOfTwo(int[] nums, int SumToFind)
        {
            // todo
            HashSet<int> seen = new HashSet<int>();
            HashSet<string> pairs = new HashSet<string>();

            foreach (int n in nums)
            {

                int missing = SumToFind - n;
                // wenn die fehlende Zahl schon gesehn wurde -> wir haben ein Paar
                if (seen.Contains(missing))
                {

                    // Paar eindeutig machen, damit (1,1) nur einmal vorkommt
                    int a = Math.Min(n, missing);
                    int b = Math.Max(n, missing);

                    pairs.Add($"{a}, {b}");
                }

                seen.Add(n);
            }
            return pairs.Count;
        }
    }
}
