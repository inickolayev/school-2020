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
	int t, n;
	cin >> t;
	fr(o, t)
	{
		cin >> n;
		vector<int> a(n);
		vector<bool> fs(n);
		fr(i, n)
			cin >> a[i];
		int l = n - 1;
		for (int i = n - 1; i >= 0; i--)
		{
			l = min(l, i - a[i]);
			if (i > l)
			{
				if (i > 0)
					fs[i - 1] = true;
				else
					fs[n - 1] = true;
			}
		}
		bool flag = true;
		fr(i, n)
			flag = flag && fs[i];
		if (flag)
			cout << "YES" << endl;
		else
			cout << "NO" << endl;
	}
	return 0;
}