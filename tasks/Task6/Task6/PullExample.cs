using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task6
{
    public class PullExample
    {
        public static void Run()
        {
            WriteLine("\nenumerables: foreach");
            IEnumerable<int> number = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            foreach (var x in number) Write(x + " "); WriteLine();

            WriteLine("enumerables: queries (filter) - Where(x => x % 2 == 0)");
            var ys = number.Where(x => x % 2 == 0);
            foreach (var y in ys) Write(y + " "); WriteLine();

            WriteLine("enumerables: queries (map) - Select(x => x * x)");
            ys = number.Select(x => x * x);
            foreach (var y in ys) Write(y + " "); WriteLine();

            WriteLine("enumerables: Take 10 ");
            ys = number.Take(10);
            foreach (var y in ys) Write(y + " "); WriteLine();

            WriteLine("enumerables: Skip 5 ");
            ys = number.Skip(5);
            foreach (var y in ys) Write(y + " "); WriteLine();
            
        }
    }
}
