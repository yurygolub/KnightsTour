using System;
using System.Diagnostics;

namespace KnightsTour
{
    public class Program
    {
        public static void Main()
        {
            int rows = 6, columns = 6;
            int startRow = 3, startCol = 2;

            Stopwatch stopwatch = Stopwatch.StartNew();
            (int row, int column)[] result = new Solver(rows, columns).Solve(startRow, startCol);
            stopwatch.Stop();

            foreach (var (row, column) in result)
            {
                Console.WriteLine($"row: {row}\tcolumn: {column}");
            }

            Console.WriteLine($"ElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
