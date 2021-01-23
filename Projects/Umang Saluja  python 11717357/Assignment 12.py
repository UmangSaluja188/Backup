#Program 1
a=3
try:
    if a<4:
        a=a/(a-3)
        print(a)
except(ZeroDivisionError):
    print("Division by zero is not possible")

#Program 2
l=[1,2,3]
try:
    print(l[3])
except(IndexError):
    print("This index is not present in list")

#Program 3
try:
    raise NameError("Hi there")
except NameError:
    print ("An exception")
    raise

#Program 4

def AbyB(a,b):
    try:
        c=((a+b)/(a-b))
    except ZeroDivisionError:
        print("a/b result in o")
        else:
            print(c)
'''Output:
            >>> AbyB(2,4)
-3.0
>>> 
>>> AbyB(4,2)
3.0
>>> AbyB(2.0,3.0)
-5.0'''
