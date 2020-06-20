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
            // 예제 문제
            int[,] edge = new int[7, 2];
            edge[0, 0] = 3;
            edge[0, 1] = 6;
            edge[1, 0] = 4;
            edge[1, 1] = 3;
            edge[2, 0] = 3;
            edge[2, 1] = 2;
            edge[3, 0] = 1;
            edge[3, 1] = 3;
            edge[4, 0] = 1;
            edge[4, 1] = 2;
            edge[5, 0] = 2;
            edge[5, 1] = 4;
            edge[6, 0] = 5;
            edge[6, 1] = 2;

            // 정답 확인
            int v = solution(6, edge);
        }

        public static int solution(int n, int[,] edge)
        {
            int answer = 0;

            // 이번에도 N이 1부터 시작이라서 편하게 하기위해 인덱스를 1늘려서 진행

            // checks로 지나온 노드는 true로 변경
            bool[] checks = new bool[20001];
            Queue<int>[] nextNode;
            nextNode = new Queue<int>[n + 1];

            // 노드 수만큼 다음 노드에 대한 정보를 갖는 Queue를 생성
            for (int i = 0; i<n+1; ++i)
            {
                nextNode[i] = new Queue<int>();
            }

            // 각 노드의 간선 정보를 입력
            // 두번 입력하는 이유는 양방향성이기 때문에
            for(int i = 0; i < edge.GetLength(0); ++i)
            {
                nextNode[edge[i, 0]].Enqueue(edge[i, 1]);
                nextNode[edge[i, 1]].Enqueue(edge[i, 0]);
            }

            // 마지막 노드를 저장해둘 큐 객체
            Queue<int> leaf = new Queue<int>();

            // 1번노드에서 시작하기 때문에 1번 값은 True로 변경
            checks[1] = true;

            // 1번노드에서 다음 노드에 대한 값을 leaf 객체에 저장
            for(int i = 0; i<nextNode[1].Count;)
            {
                int index = nextNode[1].Dequeue();
                if(!checks[index])
                {
                    checks[index] = true;
                    leaf.Enqueue(index);
                }
            }

            // leaf노드가 비워질때 까지 계산
            while(true)
            {
                // leaf가 비워지기 전에 가지고있는 노드 갯수가 가장 먼 노드들의 갯수이기 때문에 미리 저장함
                answer = leaf.Count;
                // leaf노드가 가지고있는 노드값들을 저장함
                int[] index = new int[leaf.Count];
                for(int i = 0; leaf.Count>0; i++)
                    index[i] = leaf.Dequeue();

                foreach (int i in index)
                {   
                    // 노드들의 다음 노드 정보를 꺼내서 가지 않았던 노드면 leaf에 저장
                    // 갖던노드인 경우 버림
                    for (int k = 0; k < nextNode[i].Count;)
                    {
                        int nextIndex = nextNode[i].Dequeue();
                        if (!checks[nextIndex])
                        {
                            checks[nextIndex] = true;
                            leaf.Enqueue(nextIndex);
                        }
                    }
                }

                // 다음 노드가 없거나 모두 갖던 노드인 경우 leaf에는 값이 남지 않게됨
                if(leaf.Count == 0)
                {
                    break;
                }
            }

            return answer;
        }
    }
}
