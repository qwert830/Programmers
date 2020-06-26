using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p = new int[3] { 93, 30, 55 };
            int[] s = new int[3] { 1, 30, 5 };

            var t = solution(p, s);

        }

        public static int[] solution(int[] progresses, int[] speeds)
        {
            int[] answer = new int[100];

            int answerIndex = 0;
            int k = 0;

            while (k < progresses.Length)
            {
                for (int i = 0; i < progresses.Length; i++)
                {
                    progresses[i] += speeds[i];
                }

                int n = 0;
                
                while(true)
                {
                    if(progresses[k] < 100)
                    {
                        break;
                    }
                    else
                    {
                        k++;
                        n++;
                        if(k >= progresses.Length)
                        {
                            break;
                        }
                    }
                }
                if(n > 0)
                {
                    answer[answerIndex] = n;
                    answerIndex++;
                }
            }

            Array.Resize(ref answer, answerIndex);

            return answer;
        }
    }
}
