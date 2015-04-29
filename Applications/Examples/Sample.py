#!/usr/bin/python
"""

Sample.py

Sends Morse code to a serial port and/or the speakers.

"""

from pykob import kob, morse
import time

AUDIO = True
PORT = None
#PORT = 'COM3'  # typical for Windows
#PORT = '/dev/ttyUSB0'  # typical for Linux
WPM = 40  # code speed
TEXT = '~ The quick brown fox +'  # ~ opens the circuit, + closes it

myKOB = kob.KOB(echo=True)
mySender = morse.Sender(WPM)


print "Hi"
# send HI at 20 wpm as an example
code = (-1000, +2, -1000, +60, -60, +60, -60, +60, -60, +60, -180, +60, -60, +60, -1000, +1)
myKOB.sounder(code)
time.sleep(1)

# then send the text
for c in TEXT:
    print c
    code = mySender.encode(c)
    myKOB.sounder(code)

time.sleep(1)
