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
    int testCount = inf.readInt(1, COUNT_LIM, "testCount");
    inf.readEoln();
    int sumCount = 0;

    fr(o, testCount)
    {
        int n = inf.readInt(2, COUNT_LIM, "n");

        sumCount += n;
        inf.readEoln();

        fr(i, n)
        {
            inf.readInt(0, VALUE_LIM, "p_i");
            if (i < n - 1)
                inf.readSpace();
        }
        inf.readEoln();
    }
    inf.readEof();

    ensuref(sumCount <= COUNT_LIM, "Sum of all counts must be lees or equals 100'000");
}