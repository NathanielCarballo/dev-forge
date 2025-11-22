def cb(n):
    if n < 0:
        raise ValueError("Input must be a non-negative integer")
    
    c = 0
    while n:
        c += n & 1
        n >>= 1
    return c

n=int(input("Enter a non-negative interger: "))
print(f"The number of 1 bits in the binary representation of {n} is: {cb(n)}")