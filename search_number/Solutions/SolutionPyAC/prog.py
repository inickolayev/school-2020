def bs(x):
    i = 0
    j = len(arr)-1
    while i < j:
        m = int((i+j)/2)
        if x > arr[m]:
            i = m+1
        else:
            j = m
    if arr[j] == x:
        return "Yes"
    else:
        return "No"

n,q = list(map(int, input().split()))
arr = list(map(int, input().split()))
arr.sort()


for i in range(q):
    a = int(input())
    print(bs(a))
