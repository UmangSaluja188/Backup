#Program 1
i=0
l1=[]
while(i<10):
    l1.append(int(input()))
    i=i+1
i=0
while(i<10):
    print(l1[i])
    i = i + 1

#Program 2
while(True):
    print("Infinite loop")

#Program 3
i=0
l1=[]
l2=[]
while(i<10):
    l1.append(int(input()))
    i=i+1
i=0
while(i<10):
    l2.append(l1[i]*l1[i])
    i=i+1

print("List1 Element is=",l1)
print("List2 Element is=",l2)

#Program 4
i=0
l1=[1,'Monika',1.52,'Subham',6]
print("Please Enter List Element Of Any Type=")

i=0
print(l1)
while(i<5):
    print(type(l1[i]))
    i=i+1

#Program 5
l1=[]
l2=[]
i=1
while(i<=101):
    if i%2==0:
        l2.append(i)
    else:
        l1.append(i)
    i=i+1

print("Odd No. List ",l1)
print("Even No. List ",l2)

#Program 6
for i in range(1,4):
    for j in range(0,i):
        print("*",end=" ")
    print()

#Program 7
d={'Name':'Monika Singh',2:5,'Father Name':'S.B Singh','Mother Name':'Anjali Singh'}
for key in d:
    print(key,":",d[key])
