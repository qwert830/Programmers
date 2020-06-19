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
            //결과 테스트
            int[] a = solution(1);

            return;
        }

        public static int[] solution(int n)
        {
            // 정답 변수
            int[] answer = new int[] { };
            // 초기 입력 배열 변수
            int[] input = new int[1] { 0 };

            // n = 1인 경우
            answer = input;

            // n != 1인 경우
            for(int i =1; i<n; ++i)
            {
                answer = func(answer);
            }

            return answer;
        }

        // 배열 계산 함수
        public static int[] func(int[] a)
        {
            // 기본값은 0
            // 종이를 한번 접으면 0'/ 0 /1' 이전 배열에서 0을 추가하고 0은 1로 1은0으로 바꾸어서 넣어준다
            // 이때 인덱스 순서는 0 1 2 / 0 / 2 1 0
            // 0 0 1 다음 배열은
            // 0 0 1 / 0 / 0 1 1
            int[] result = new int[a.Length * 2 + 1];
            for(int i = 0; i<= (a.Length*2); ++i)
            {
                if(a.Length>i)
                {
                    result[i] = a[i];
                }
                else if(a.Length == i)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = 1 - a[(a.Length*2) - i];
                }
            }
            return result;
        }
    }
}
