using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 가독성을위해 pair로 자료형 이름사용
using pair = System.Collections.Generic.KeyValuePair<int, int>;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 테스트 코드
            var r = solution("ULURRDLLU");
        }

        public static int solution(string dirs)
        {
            int answer = 0;

            // <시작지점 x,y 도착지점 x,y>
            Dictionary<KeyValuePair<pair, pair>, bool> di = new Dictionary<KeyValuePair<pair, pair>, bool>();

            // 시작위치
            int x = 0; int y = 0;

            for(int i = 0; i<dirs.Length; ++i)
            {
                //명령어 해석
                switch(dirs[i])
                {
                    // try문으로 di에 이미 들어있는 값은 answer값을 증가시키지 않고 위치만 이동시킴
                    // di에 이미있는 키값을 집어넣을경우 오류발생함.
                    case 'U':
                        //이동제한 조건
                        if (y == 5)
                            break;
                        try
                        {
                            di.Add(new KeyValuePair<pair, pair>(new pair(x, y), new pair(x, y + 1)),true);
                            di.Add(new KeyValuePair<pair, pair>(new pair(x, y+1), new pair(x, y)), true);
                            y += 1;
                            answer++;
                        }
                        catch
                        {
                            y += 1;
                        }
                        break;
                    case 'D':
                        //이동제한 조건
                        if (y == -5)
                            break;
                        try
                        {
                            di.Add(new KeyValuePair<pair, pair>(new pair(x, y), new pair(x, y - 1)), true);
                            di.Add(new KeyValuePair<pair, pair>(new pair(x, y - 1), new pair(x, y)), true);
                            y -= 1;
                            answer++;
                        }
                        catch
                        {
                            y -= 1;
                        }
                        break;
                    case 'R':
                        //이동제한 조건
                        if (x == 5)
                            break;
                        try
                        {
                            di.Add(new KeyValuePair<pair, pair>(new pair(x+1, y), new pair(x, y)), true);
                            di.Add(new KeyValuePair<pair, pair>(new pair(x, y), new pair(x+1, y)), true);
                            x += 1;
                            answer++;
                        }
                        catch
                        {
                            x += 1;
                        }

                        break;
                    case 'L':
                        //이동제한 조건
                        if (x == -5)
                            break;
                        try
                        {
                            di.Add(new KeyValuePair<pair, pair>(new pair(x, y), new pair(x-1, y)), true);
                            di.Add(new KeyValuePair<pair, pair>(new pair(x-1, y), new pair(x, y)), true);
                            x -= 1;
                            answer++;
                        }
                        catch
                        {
                            x -= 1;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}
