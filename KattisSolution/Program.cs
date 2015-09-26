using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using KattisSolution.IO;

namespace KattisSolution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Solve(Console.OpenStandardInput(), Console.OpenStandardOutput());
        }

        public static void Solve(Stream stdin, Stream stdout)
        {
            IScanner scanner = new OptimizedPositiveIntReader(stdin);
            // uncomment when you need more advanced reader
            // scanner = new Scanner(stdin);
            // scanner = new LineReader(stdin);
            var writer = new BufferedStdoutWriter(stdout);

            var n = scanner.NextInt();
            var m = scanner.NextInt();

            if (n == 1)
            {
                writer.Write(1);
                writer.Write("\n");
                writer.Flush();
                return;
            }

            if (m == 1)
            {
                writer.Write(2);
                writer.Write("\n");
                writer.Flush();
                return;
            }

            if (m == 0)
            {
                writer.Write(1);
                writer.Write("\n");
                writer.Flush();
                return;
            }

            var meetings = new Dictionary<int, HashSet<int>>(n);

            for (int i = 0; i < m; i++)
            {
                int a = scanner.NextInt();
                int b = scanner.NextInt();

                HashSet<int> forA;
                if (meetings.ContainsKey(a))
                {
                    forA = meetings[a];

                    if (!forA.Contains(b))
                        forA.Add(b);
                }
                else
                {
                    forA = new HashSet<int> { b };
                    meetings.Add(a, forA);
                }

                HashSet<int> forB;
                if (meetings.ContainsKey(b))
                {
                    forB = meetings[b];

                    if (!forB.Contains(a))
                        forB.Add(a);
                }
                else
                {
                    forB = new HashSet<int> { a };
                    meetings.Add(b, forB);
                }
            }

            answer = -1;
            BronKerbosch1(new int[0], Enumerable.Range(1, n).ToArray(), new int[0], meetings);

            Debug.WriteLine("Answer updated {0} time!", answerUpdated);

            //            if (answer.Count == 0)
            //                writer.Write(2);
            //            else
            writer.Write(answer);
            writer.Write("\n");
            writer.Flush();
        }

        public static int answer;
        private static int answerUpdated;

        public static void BronKerbosch1(int[] R, int[] P, int[] X, Dictionary<int, HashSet<int>> neighbors)
        {
            //if P and X are both empty:
            if (!P.Any() && !X.Any())
            // report R as a maximal clique
            {
                if (R.Count() > answer)
                {
                    answerUpdated++;
                    answer = R.Count();
                }
                return;
            }

            var pCopy = P.ToArray();

            // for each vertex v in P:
            foreach (var v in pCopy)
            {
                var vGraph = new[] { v };
                //P := P \ {v}
                P = P.Except(vGraph).ToArray();

                var vNeigbors = neighbors.ContainsKey(v) ? neighbors[v] : new HashSet<int>();

                //BronKerbosch1(R ⋃ {v}, P ⋂ N(v), X ⋂ N(v))
                BronKerbosch1(R.Union(vGraph).ToArray(), P.Intersect(vNeigbors).ToArray(),
                    X.Intersect(vNeigbors).ToArray(), neighbors);
                //


                //X := X ⋃ {v}
                X = X.Intersect(vGraph).ToArray();

                //                if (answer > 0)
                //                    return;
            }
        }
    }
}