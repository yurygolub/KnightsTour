using System;
using System.Diagnostics;

namespace KnightsTour
{
    public class Program
    {
        public static void Main()
        {
            int rows = 5, columns = 6;
            int startRow = 2, startCol = 3;

            Stopwatch stopwatch = Stopwatch.StartNew();
            var solutions = new Solver(rows, columns).Solve(startRow, startCol);
            stopwatch.Stop();

            foreach (var solution in solutions)
            {
                foreach (var (row, column) in solution)
                {
                    Console.WriteLine($"row: {row}\tcolumn: {column}");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Solutions count: {solutions.Count}");
            Console.WriteLine($"ElapsedMilliseconds: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
