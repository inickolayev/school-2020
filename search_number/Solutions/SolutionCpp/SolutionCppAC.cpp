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

const ll LIM = 998'244'353;

bool bin_search(ll p, int n, vector<ll>& a)
{
	int l = 0, r = n - 1, m;
	while (r - l > 1)
	{
 		m = (l + r) / 2;
		if (a[m] == p)
			return true;
		else if (a[m] < p)
			l = m;
		else
			r = m;
	}
	return a[l] == p || a[r] == p;
}

int main()
{
	int n, q;
	cin >> n >> q;
	vector<ll> a(n);
	fr(i, n)
		cin >> a[i];
	sort(a.begin(), a.end(), less<ll>());
	fr(i, q)
	{
		ll p;
		cin >> p;
		cout << (bin_search(p, n, a) ? "Yes" : "No") << endl;
	}
	return 0;
}