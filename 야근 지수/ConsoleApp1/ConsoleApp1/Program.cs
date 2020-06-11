using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = solution(7, new int[5] {4,4,4,1,6});

            Console.WriteLine("result : {0}", t);
        }

        public static long solution(int n, int[] works)
        {
            long answer = 0;

            SortedList<int,int> list = new SortedList<int,int>();
            for(int i =0; i<works.Length; ++i)
            {
                int value = 0;
                if(list.TryGetValue(works[i], out value))
                {
                    list[works[i]] += 1;
                }
                else
                {
                    list.Add(works[i], 1);
                }
            }

            for (int i = 0; i < n; ++i)
            {
                int value = 0;
                int index = list.Keys.Last();

                if (list[index] <= (n-i))
                {
                    int dis = list[index];
                    i += dis-1;
                    list.Remove(index);

                    if (list.TryGetValue(index - 1, out value))
                    {
                        list[index - 1] += (dis);
                    }
                    else
                    {
                        list.Add(index - 1, (dis));
                    }
                }
                else
                {
                    list[index] -= 1;
                    if (list.TryGetValue(index - 1, out value))
                    {
                        list[index - 1] += 1;
                    }
                    else
                    {
                        list.Add(index - 1, 1);
                    }
                }
            }

            foreach(var k in list)
            {
                for (int i = 0; i < k.Value; ++i)
                {
                    if (k.Value > 0 && k.Key >0)
                        answer += k.Key * k.Key;
                }
            }

             return answer;
        }
    }
}
