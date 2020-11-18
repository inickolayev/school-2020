#include "string"
#include "testlib.h"

#define fr(i, n) for(int i = 0; i < n; i++)
#define fre(i, n) for(int i = 0; i <= n; i++)
#define frs(i, st, n) for(int i = st; i < n; i++)
#define frse(i, st, n) for(int i = st; i <= n; i++)

typedef long long int ll;
typedef unsigned long long int ull;

const int COUNT_LIM = 100'000;
const int VALUE_LIM = 1000'000'000;

int main(int argc, char* argv[]) {
    registerValidation(argc, argv);

    int n = inf.readInt(1, COUNT_LIM, "n");
    inf.readSpace();
    int q = inf.readInt(1, COUNT_LIM, "q");
    inf.readEoln();
    ensuref(q <= n * q, "Sum of strings length must be less or equals 100'000");


    auto s = inf.readToken("[a-z]+", "s");
    ensuref(s.length() == n, "Length of string must be equals n");
    inf.readEoln();
    fr(o, q)
    {
        auto si = inf.readToken("[a-z]+", "si");
        ensuref(si.length() == n, "Length of string must be equals n");
        inf.readEoln();
    }
    inf.readEof();
}