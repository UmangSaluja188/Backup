#Program 1
def circleArea(radius):
    piValue=3.14
    area=piValue*radius*radius
    print("Area Of Circle is=",area)

r=int(input("Please Enter radius of circle="))
circleArea(r)

#Program 2
def perfect(no):
    i=1
    sum=0
    while(i<no):

        if no%i==0:
            sum+=i
        i=i+1
    if sum==no:
        print("perfect no")
    else:
        print("not perfect no")

no=int(input("Please input ny no="))
perfect(no)

#Program 3
def  tfunc(i):
    if i>10:
        return
    print("12*", i, "=", 12*i )
    i=i+1
    tfunc(i)

tfunc(1)

#Program 4
def calculatePower(no,power,value,i):
    if i>power:
        print("Total =",value)
        return
    value*=no
    i=i+1
    calculatePower(no,power,value,i)

no=int(input("Please Enter No="))
pow=int(input("Please Enter Power="))
value=1
i=1
calculatePower(no,pow,value,i)

#Program 5
def fac(no):
    dic={}
    if no<=0:
        print("Sorry factorial is not possible")
    else:
        factorial=no
        i=no-1
        while(i>=1):
            factorial*=i
            i=i-1
        print("Factorial of ",no," is=",factorial)
        dic.update({"Factorial":factorial})
        print(dic)
no=int(input("Please Enter Any No="))
fac(no)


