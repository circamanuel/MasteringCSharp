using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace Cats_and_food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotHungryCats("~O~O~O~O F");
            NotHungryCats("O~~O~O~O F O~O~");
        }

        public static int NotHungryCats(string kitchen)
        {
            // Leerzeichen entfernen und an F splitten
            string[] sides = kitchen.Replace(" ", "").Split('F');

            string patternL = "O~";  // links nicht hungrig
            string patternR = "~O";  // rechts nicht hungrig

            int matchesL = countPairs(sides[0], patternL); // links vom F
            int matchesR = 0;

            if (sides.Length > 1)
            {
                matchesR = countPairs(sides[1], patternR); // rechts vom F
            }

            int total = matchesL + matchesR;

            if (total > 0)
            {
                Console.WriteLine($"{total} (one is not following)");
            }
            else
            {
                Console.WriteLine($"{total} (all cats follow you)");
            }

            return total;
        }


        public static int countPairs (string side, string pattern)
        {
            int count = 0;

            for (int i = 0; i + 1 < side.Length; i += 2)
            {

                string pair = side.Substring(i, 2);

                if (pair == pattern)
                {
                    count ++;
                }
            }
            return count;
        }

    }
}
