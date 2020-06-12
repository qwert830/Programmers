#include <iostream>
#include <string>
#include <vector>

using namespace std;

// N이 1~80이라서 원래대로라면 80을 선언 후 인덱스를 1씩 맞춰주어야 하는데
// 전체적으로 코드를 바꾸려니 에러가 발생해서 그대로 진행함.
static long long* nLength = new long long[81]{ 0, };

//재귀함수
long long GetLength(int N)
{
	long long result = 1;

	//탈출조건 N=1,2
	if (N == 1) result = 1;
	else if (N == 2) result = 1;
	
	//중복 계산 방지 조건
	else if (nLength[N] != 0) result = nLength[N];
	//값이 없는 경우 계산
	else if (nLength[N] == 0)
	{
		nLength[N] = GetLength(N - 1) + GetLength(N - 2);
		result = nLength[N];
	}
	return result;
}

long long solution(int N) {
	long long answer = 0;

	// N이 1~3일 경우에 각 사각형 값은 예외처리함.
	if (N == 1)
	{
		return 4;
	}
	else if (N == 2)
	{
		return 6;
	}
	else if (N == 3)
	{
		return 10;
	}

	//nLength[N]까지에 값 계산
	GetLength(N);

	// 각 변에 길이 계산
	answer = (nLength[N] + nLength[N - 1]) * 2 + (nLength[N] * 2);

	return answer;
}

int main()
{
	// 테스트 solution
	auto result = solution(80);

	cout << result << endl;

	return 0;
}

