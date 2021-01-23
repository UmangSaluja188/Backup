#Program 1
yr = int(input("Please Enter Year="));
if yr % 4==0 and year % 100 != 0 or year % 400 == 0:
    print("This Is Leap Year")
else:
    print("This Is Not Leap Year")

#Program 2
l = int(input("Please Enter length: "))
b = int(input("Please Enter breadth: "))
if(l==b):
    print("It is a square")
else:
    print("It is a rectangle")

#Program 3
Age1 = int(input("Please Enter the age of first people="))
Age2 = int(input("Please Enter the age of second people="))
Age3 = int(input("Please Enter the age of third people="))

if Age1>Age2 and Age1>Age3:
    print("First is Oldest")
elif Age2>Age3:
    print("Second is Oldest")
else:
    print("Third Is Oldest")

#Program 4
points = int(input("Please Enter Points"))

if points >= 181 and points <= 200:
    print(" Congratulation! You won Chocolates")
elif points>=151 and points <=180:
    print("Congratulation! You won  Book")
elif points>=51 and points <=150:
    print("Congratulation! You won  Wooden Dog")
elif points>=1 and points <=50:
    print("No Prize")
else:
    print("Sorry No Prize")
