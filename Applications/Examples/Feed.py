#!/usr/bin/env python

"""

Feed.py

Waits for a station to connect to a KOB wire and sends text from a RSS-formatted
local file or news feed in Morse at a given speed.

If the wait parameter is nonzero, then the feed will stop sending if
another station starts sending, and will wait until the wire is idle for the
specified number of seconds before sending again.

Command line parameters (required):
    wire - KOB wire no.
    idText - office call, etc.
    url - RSS formatted text source (URL)
    wpm - overall code speed (WPM)
    
Additional command line parameters (optional):
    cwpm - individual character speed (default: same as overall code speed)
    artPause - delay between articles (default: 2 sec)
    grpPause - delay between article groups (default: 5 sec)
    days - number of days of articles to read before repeating, starting with
            current day (default: all)
    wait - number of seconds to wait for the wire to be idle before sending
            (default: ignore other senders)

Note: artPause and grpPause can be decimal numbers.  wire, wpm, cwpm, and
days must be integers.  idText and url should be enclosed in quotes.

Examples:
    python Feed.py 105 "Today's News, 20 wpm, AC" "http://rss.news.yahoo.com/rss/topstories" 20
    python Feed.py 111 "Civil War News, 15 wpm, AC" "file://civilwar.xml" 15 18 5 20 3

"""

import sys
import time, datetime
import threading
import pykob
from pykob import newsreader, morse, internet, kob, log

VERSION     = '1.3'
DATEFORMAT  = '%a, %d %b %Y %H:%M:%S'
TIMEOUT     = 30.0  # time to keep sending after last indication of live listener (sec)

log.log('Starting Feed {0}'.format(VERSION))

wire = int(sys.argv[1])
idText = sys.argv[2]
url = sys.argv[3]
wpm = int(sys.argv[4])
n = len(sys.argv)
cwpm = int(sys.argv[5]) if n > 5 else 0
artPause = float(sys.argv[6]) if n > 6 else 2.0
grpPause = max(float(sys.argv[7]) if n > 7 else 5.0, artPause)
days = int(sys.argv[8]) if n > 8 else 0
wait = int(sys.argv[9]) if n > 9 else 0

mySender = morse.Sender(wpm, cwpm, morse.AMERICAN, morse.CHARSPACING)
myInternet = internet.Internet(idText)
myKOB = kob.KOB(port=None, audio=False)

myInternet.connect(wire)
##time.sleep(1)

# create thread to listen for activity on the wire
tLastSender = time.time()  # time of last activity
def checkForActivity():
    global tLastSender
    while True:
        myInternet.read()
        tLastSender = time.time()
listenerThread = threading.Thread(target=checkForActivity)
listenerThread.daemon = True
listenerThread.start()

def activeListener():
    return time.time() < myInternet.tLastListener + TIMEOUT

def activeSender():
    return time.time() < tLastSender + wait

def send(code):
    myInternet.write(code)
    myKOB.sounder(code)  # to pace the code sent to the wire

while True:
    articles = newsreader.getArticles(url)
    for (title, description, pubDate) in articles:
        if days and pubDate:
            today = datetime.date.today()
            pd = datetime.datetime.strptime(pubDate[:-6], DATEFORMAT).date()
            if pd > today or today - pd >= datetime.timedelta(days):
                continue
        text = description
        if pubDate:  # treat as an article, not freeform text
            text += '  ='
        if title:
            pass  # ignore the title
        while activeSender() or not activeListener():
            time.sleep(1)
        send((-0x7fff, +2, -1000, +2))  # open circuit and wait 1 sec
        for char in text:
            if activeSender() or not activeListener():
                break
            code = mySender.encode(char)
            if code:
                send(code)
        send((-1000, +1))  # close circuit after 1 sec
        time.sleep(artPause)
    time.sleep(grpPause - artPause)
