#Program 1
l1=list();
num=int(input("How Many Values You Want To Enter= "))
for  i in range(0,num):
    val=input("Enter Value= ")
    l1.append(val)
print (l1)

#Program 2
l1=[];
num=int(input("How Many Values You Want To Enter= "))
for  i in range(0,num):
    val=input("Enter Value= ")
    l1.append(val)

l2=['google','apple','facebook','microsoft','tesla']

l1=l1+l2
print (l1)

#Program 3
l1=[5,1,6,5,5,3,5,7,1]
val=l1.count(5)
print(val)

#Program 4
l1=[5,4,3,2,1]
l1.sort()
print(l1)
