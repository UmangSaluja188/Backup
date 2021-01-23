#Program 2
import datetime
now = datetime.datetime.now()
print ("Current time : ")
print (now.strftime("%H:%M:%S"))

#Program 3
import datetime
now = datetime.datetime.now()
print ("Current date and time : ")
print (now.strftime("%m"))

#Program 4
import datetime
now = datetime.datetime.now()
print ("Current date and time : ")
print (now.strftime("%d"))

#Program 5
import datetime
now = datetime.datetime.now()
print ("Current date and time : ")
print (now.strftime("%d/%m/%y"))

import datetime
import time
localtime=time.asctime(time.localtime(time.time()))
print(localtime)
