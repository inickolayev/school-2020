#include <iostream>
#include <vector>

using namespace std;
bool linear_found(long long a, vector<long long>& vct) {
	for (int i = 0; i < vct.size(); ++i) {
		if (vct[i] == a)
			return true;
	}
	return false;
}
int main() {
	int n, q;
	cin >> n >> q;
	vector<long long> vct(n);
	for (auto& v : vct)
		cin >> v;
	long long a;
	for (int i = 0; i < q; ++i) {
		cin >> a;
		if (linear_found(a, vct)) {
			cout << "YES\n";
		}
		else
			cout << "NO\n";
	}
}