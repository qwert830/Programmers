using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main()
        {
            // 테스트 string[] 문자열
            string[] a = new string[] { "I 16", "I -5643", "D -1", "D 1", "D 1", "I 123", "D -1" };

            var t = solution(a);

            Console.WriteLine("[" + t[0].ToString() + ", " + t[1].ToString() + "]");
        }

        public static int[] solution(string[] operations)
        {
            //return 해줄 결과 값
            int[] answer = new int[2] { 0, 0 };
            // 명령으로 들어온 값을 저장할 자료구조
            // key값은 입력된 값, value값은 중복된 경우를 생각한 카운트 값
            SortedDictionary<int, int> di = new SortedDictionary<int, int>(); 

            foreach (var i in operations)
            {
                //[0]번째 string 값은 명령어 커맨드
                //[1]번째 string 값은 입력할 수치 or 추가 커맨드(1, -1)
                switch (i.Split(' ')[0])
                {
                    case "I":
                        int value = 0;
                        //di에 값을 추가하기전에 키값이 있는지 확인 
                        //없으면 value값으로 1, 있으면 기존 value + 1 입력하여 카운트용도로 사용
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
                        //di에 값이 없어도 삭제 명령어가 들어올수 있고 그런경우 해당 명령어를 무시해야함
                        if (di.Count > 0)
                        {
                            // 최소값 삭제 커맨드 처리
                            if (i.Split(' ')[1] == "-1")
                            {
                                // 정렬된 자료구조이기 때문에 첫번째 키값으로 카운트를 제거하거나 카운트가 1인경우 삭제함
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
                            // 최대값 삭제 커맨드 처리
                            else
                            {
                                // 마지막 키값으로 검색하여 카운트 제거 및 삭제 처리
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

            // 모두 삭제된 경우 or 하나도 입력되지 않은 경우
            if (di.Count == 0)
            {
                answer[0] = 0;
                answer[1] = 0;
            }
            // 한개 키값만 남아서 min,max값이 동일한 경우
            else if (di.Count == 1)
            {
                answer[0] = di.Keys.First();
                answer[1] = di.Keys.First();
            }
            // 2개 이상 값이 남아서 min,max값이 다른 경우
            else
            {
                answer[0] = di.Keys.First();
                answer[1] = di.Keys.Last();
            }

            return answer;
        }
    }
}