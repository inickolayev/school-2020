#include<iostream>
#include<string>
#include<vector>
#include<map>
#include<set>
#include<queue>
#include<list>
#include<cmath>
#include<algorithm>
using namespace std;

#define fr(i, n) for(int i = 0; i < n; i++)
#define fre(i, n) for(int i = 0; i <= n; i++)
#define frs(i, st, n) for(int i = st; i < n; i++)
#define frse(i, st, n) for(int i = st; i <= n; i++)

typedef long long int ll;
typedef unsigned long long int ull;

const int LIM = 5 * 1000'000 + 10;

int main()
{
	ll n, k;
	cin >> n >> k;
	if (k < 5)
	{
		if (n >= 10)
		{
			ll ansK = 1;
			frse(i, 1, k)
				ansK *= i;
			cout << (9 * ansK) % 10;
		}
		else
		{
			ll ansK = 1;
			frse(i, 1, k)
				ansK *= i;
			ll ansN = 1;
			frse(i, 1, n)
				ansN *= i;
			cout << (ansN - ansK) % 10;
		}
	}
	else
		cout << 0;
	return 0;
}