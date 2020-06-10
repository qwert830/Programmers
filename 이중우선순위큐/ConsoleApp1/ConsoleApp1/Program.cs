using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main()
        {
            string[] a = new string[] { "I 16", "I -5643", "D -1", "D 1", "D 1", "I 123", "D -1" };

            var t = solution(a);

            Console.WriteLine("[" + t[0].ToString() + ", " + t[1].ToString() + "]");
        }

        public static int[] solution(string[] operations)
        {
            int[] answer = new int[2] { 0, 0 };
            SortedDictionary<int, int> di = new SortedDictionary<int, int>();

            foreach (var i in operations)
            {
                switch (i.Split(' ')[0])
                {
                    case "I":
                        int value = 0;
                        if (di.TryGetValue(int.Parse(i.Split(' ')[1]), out value))
                        {
                            di[int.Parse(i.Split(' ')[1])] = value + 1;
                        }
                        else
                        {
                            di.Add(int.Parse(i.Split(' ')[1]), 1);
                        }
                        break;

                    case "D":
                        if (di.Count > 0)
                        {
                            if (i.Split(' ')[1] == "-1")
                            {
                                int index = di.Keys.First();
                                if (di[index] > 1)
                                {
                                    di[index]--;
                                    break;
                                }
                                else
                                {
                                    di.Remove(index);
                                    break;
                                }
                            }
                            else
                            {
                                int index = di.Keys.Last();
                                if (di[index] > 1)
                                {
                                    di[index]--;
                                    break;
                                }
                                else
                                {
                                    di.Remove(index);
                                    break;
                                }
                            }
                        }
                        break;
                }
            }

            if (di.Count == 0)
            {
                answer[0] = 0;
                answer[1] = 0;
            }
            else if (di.Count == 1)
            {
                answer[0] = di.Keys.First();
                answer[1] = di.Keys.First();
            }
            else
            {
                answer[0] = di.Keys.First();
                answer[1] = di.Keys.Last();
            }

            return answer;
        }
    }
}