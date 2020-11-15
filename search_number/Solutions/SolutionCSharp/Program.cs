using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = arr[0], q = arr[1];
            List<long> a, p = new List<long>();
            a = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            a.Sort();
            for (int i = 0; i < q; i++)
                p.Add(long.Parse(Console.ReadLine()));
            for (int i = 0; i < q; i++)
                Console.WriteLine(BinarySearch(p[i], n, a) ? "Yes" : "No");
        }
        
        static bool BinarySearch(long p, int n, List<long> a)
        {
            int l = 0, r = n - 1, m;
            while (r - l > 1)
            {
                m = (l + r) / 2;
                if (a[m] == p)
                    return true;
                else if (a[m] < p)
                    l = m;
                else
                    r = m;
            }
            return a[l] == p || a[r] == p;
        }
    }
}
