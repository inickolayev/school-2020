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
	int n, q;
	cin >> n >> q;
	string s;
	cin >> s;
	sort(s.begin(), s.end());
	fr(i, q)
	{
		string c;
		cin >> c;
		sort(c.begin(), c.end());
		bool ans = s == c;
		cout << (ans ? "YES" : "NO") << endl;
	}
	return 0;
}