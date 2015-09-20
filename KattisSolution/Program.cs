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

            var result = 0;

            foreach (var meeting in meetings.OrderByDescending(g => g.Value.Count))
            {
                // we know that for key all connections are there
                var everyoneBumped = new HashSet<int> { meeting.Key };
                Debug.WriteLine("Checking " + meeting.Key + " with: " + string.Join(", ", meeting.Value));

                for (int j = 0; j < meeting.Value.Count; j++)
                {
                    var personA = meeting.Value.ElementAt(j);

                    for (int i = j + 1; i < meeting.Value.Count; i++)
                    {
                        var personB = meeting.Value.ElementAt(i);
                        //Debug.WriteLine("Looking for {0} =? {1}", personA, personB);
                        if (!meetings[personA].Contains(personB))
                        {
                            //Debug.WriteLine("{0} <-> {1} not found", personA, personB);
                            personA = -1;
                            break;
                        }
                    }

                    if (personA > 0)
                        everyoneBumped.Add(personA);
                }

                Debug.WriteLine("Found group: " + string.Join(", ", everyoneBumped));
                result = Math.Max(everyoneBumped.Count, result);
            }

            writer.Write(result);
            writer.Write("\n");
            writer.Flush();
        }

        public class Group
        {
            public Group(int a, int b)
            {
                Meetings = 1;
                People = new HashSet<int> { a, b };
            }

            public readonly HashSet<int> People;
            public int Meetings;

            public void Add(int a, int b)
            {
                if (!People.Contains(a))
                    People.Add(a);
                if (!People.Contains(b))
                    People.Add(b);
                Meetings++;
            }
        }
    }
}