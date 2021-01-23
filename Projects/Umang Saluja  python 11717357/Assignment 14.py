#Program 1
import re

emails= ''' zuck26@facebook.com
                 page33@google.com
                 jeff42@amazon.com
             ''' 

l1 = re.findall('\S+@\S+', emails)
print(l1)

#Program 2
import re

text='''Betty bought a bit of butter was so bitter,
           So she bought some better butter,
           To make the bitter butter better
           '''
l1 = re.findall("[ae]\w+", text)
print(l1)

#Program 3
import re

sentence='''A, very very; irregular_sentence'''
l1=re.split(";",sentence)
print(l1)

