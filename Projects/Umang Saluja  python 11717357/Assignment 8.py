#Program 1
class Circle:
    def __init__(self,r,pi):
        self.r=2
        self.pi=3.14
    def getArea(self):
        print(pi*r*r)
    def getCircumference(self):
        print(2*pi*r)

#Program 2
class Student:
    def __init__(self):
        self.name=input("Enter your name : ")
        self.roll_no=int(input("Enter your roll no. : "))
    def display(self):
        print("Hello you are: ",self.name)
        print("Your roll no. is: ",self.roll_no)

#Program 3
class Temperature:
    def __init__(self,celsius,fahrenheit):
        self.celsius = 37.5
    def convertFahrenheit(self):
        fahrenheit = (celsius * 1.8) + 32
        print(fahrenheit)
    def convertCelsius):
        celsius = (fahrenheit-32)/1.8
        print(celsius)

#Program 4
class Student:
    def __init__(self,mname,a,y,r):
        self.mname=input("Enter movie name : ")
        self.a=int(input("Enter artist name : "))
        self.y=int(input("Enter year of release : "))
        self.a=int(input("Enter ratings : "))
    def display(self):
        print("Movie name is: ",self.name)
        print("Artist name is: ",self.roll_no)
        print("Movie released in: ",self.roll_no)
        print("Rating of movie is: ",self.roll_no)
        
