
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

#pragma warning(disable : 4996)

#define fr(i, n) for(int i = 0; i < n; i++)
#define fre(i, n) for(int i = 0; i <= n; i++)
#define frs(i, st, n) for(int i = st; i < n; i++)
#define frse(i, st, n) for(int i = st; i <= n; i++)

typedef long long int ll;
typedef unsigned long long int ull;

//const ll LIM = 998'244'353;

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
	ios_base::sync_with_stdio(false);

	int n, q;
	scanf("%d %d", &n, &q);
	vector<ll> a(n), p(q);
	fr(i, n)
	{
		ll ai;
		scanf("%I64d", &ai);
		a[i] = ai;
	}
	sort(a.begin(), a.end(), less<ll>());
	fr(i, q)
	{
		ll pi;
		scanf("%I64d", &pi);
		p[i] = pi;
	}
	fr(i, q)
		printf("%s\n", (bin_search(p[i], n, a) ? "Yes" : "No"));
	return 0;
}