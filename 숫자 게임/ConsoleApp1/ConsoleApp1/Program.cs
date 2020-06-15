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
            int[] a = new int[4] { 5, 1, 3, 7 };
            int[] b = new int[4] { 2, 2, 6, 8 };

            var t = solution(a, b);
            Console.Write(t);
        }

        public static int solution(int[] A, int[] B)
        {
            int answer = 0;

            Array.Sort(A);
            Array.Sort(B);

            int length = A.Length;

            for(int i =0; i<length;)
            {
                for(int j = 0; j<length;)
                {
                    if(A[i]>=B[j])
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                        j++;
                        answer++;
                    }
                }
                break;
            }

            return answer;
        }
    }
}
