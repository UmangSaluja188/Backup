#Program 1
f=open("writeFile.txt","r")
print(f.readlines())

#Program 2
wr=open("writeFile.txt",'a+')
rd=open("readFile.txt",'r')
with open("readFile.txt",'r') as f:
    data=f.read()
    for var in data:
        wr.write(var);
rd.close()
wr.close()

#Program 3
wr=open("newwriteFile.txt",'a+')
rd =open ("f1.txt" , 'r')
with open("f1.txt", 'r') as f:
    data = rd.readLine()
    for var in data:
        wr.writeLine(var);
rd.close()
wr.close()



