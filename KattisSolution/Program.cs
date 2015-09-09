using System;
using System.IO;
using KattisSolution.IO;

namespace KattisSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve(Console.OpenStandardInput(), Console.OpenStandardOutput());
        }

        public static void Solve(Stream stdin, Stream stdout)
        {
            IScanner scanner = new OptimizedPositiveIntReader(stdin);
            // uncomment when you need more advanced reader
            // scanner = new Scanner(stdin);
            // scanner = new LineReader(stdin);
            BufferedStdoutWriter writer = new BufferedStdoutWriter(stdout);

            var input = scanner.NextInt();

            writer.Write(input * 5);
            writer.Write("\n");
            writer.Flush();
        }
    }
}
