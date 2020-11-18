#include "testlib.h"

typedef long long int ll;

const ll LIM = 1000'000'000'000'000'000;

int main(int argc, char* argv[]) {
    registerValidation(argc, argv);
    ll n = inf.readLong(1, LIM, "n");
    inf.readSpace();
    ll k = inf.readLong(1, n, "k");
    inf.readEoln();
    inf.readEof();
}