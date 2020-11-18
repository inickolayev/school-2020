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

const int LIM = 1000'000'000 + 7;

int d[1000'000][20];

int cnk(int n, int k)
{
	if (d[n][k] > 0)
		return d[n][k];
	if (n == 1 || n == k || k == 0)
		return 1;
	d[n][k] = (cnk(n - 1, k - 1) + cnk(n - 1, k)) % LIM;
	return d[n][k];
}

int main()
{
	int n, q;
	cin >> n;
	int ans1 = cnk(n, 11);
	int ans2 = cnk(n - 11, 11);
	int ans = ((ans1 * ans2) % LIM) / 2;
	cout << ans << endl;
	return 0;
}