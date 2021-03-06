#!/usr/bin/env python

"""

Time.py

Sends time signals to a KOB wire and/or to a sounder or speakers. The time
signals can be sent hourly, daily at 12:00 noon EST, or continuously (every
five minutes).

Optional command line parameters:
    mode - Continuous, Hourly, or Daily (can be lowercase, only need first
            letter, default: continuous)
    wire - KOB wire no. (default: no connection to KOB server)
    idText - office call, etc.

If wire is specified, then idText is required. Only sends over the wire if
someone is listening.

Uses config.PORT and config.AUDIO.

Examples:
    python Time.py
    python Time.py d 102 "Time signals, AC" 

"""

import sys
import time
import threading
from pykob import newsreader, morse, internet, kob
import config

VERSION = '1.2'
TIMEOUT = 30.0  # time to send after last indication of live listener (sec)
TICK    = (-1, +1, -200, +1, -200, +2) + 3 * (-200, +2)
NOTICK  = 5 * (-200, +2)
MARK    = (-1, +1) + 9 * (-200, +1) + (-200, +2)

print('')
print(time.asctime())
print('Time ' + VERSION)
sys.stdout.flush()

nargs = len(sys.argv)
mode = sys.argv[1][0] if nargs > 1 else 'c'
if nargs > 2:
    wire = int(sys.argv[2])
    idText = sys.argv[3]
else:
    wire = None

myKOB = kob.KOB(config.PORT, config.AUDIO)

if wire:
    myInternet = internet.Internet(idText)
    myInternet.connect(wire)
    time.sleep(1)

    def checkForListener():
        while True:
            myInternet.read()  # activate the reader to get tLastListener updates
            
    listenerThread = threading.Thread(target=checkForListener)
    listenerThread.daemon = True
    listenerThread.start()

def send(code):
    if wire and time.time() < myInternet.tLastListener + TIMEOUT:
        myInternet.write(code)
    myKOB.sounder(code)

while True:
    now = time.gmtime()
    hh = now.tm_hour
    mm = now.tm_min
    ss = now.tm_sec
    time.sleep(60 - ss)  # wait for the top of the minute
    nn = (mm + 1) % 5  # nn: minute 0 to minute 5
    if mode == 'c' or mode == 'h' and mm == 59 or \
            mode == 'd' and hh == 16 and mm >= 55:
        if mode == 'h':
            send(MARK)
        elif nn == 0:
            send(MARK)
            for i in range(7):
                send(NOTICK)
            send((-1, +1))  # close the circuit
        elif nn == 1:
            time.sleep(55)
            send((-1, +2))  # open the circuit
        else:
            for i in range(29):
                send(TICK)
            send(NOTICK)
            for i in range(21):
                send(TICK)
            if nn == 2:
                for i in range(2):
                    send(TICK)
                send(NOTICK)
                for i in range(2):
                    send(TICK)
            elif nn == 3:
                for i in range(2):
                    send(TICK)
                for i in range(2):
                    send(NOTICK)
                send(TICK)
            elif nn == 4:
                for i in range(5):
                    send(NOTICK)
