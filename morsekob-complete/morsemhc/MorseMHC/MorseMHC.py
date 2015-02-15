#! python3

"""
MorseMHC program
Custom version of MorseKOB for the Minnesota History Center.
Receives text from the keyboard, a file, or a web page, displays the text
on the screen, and sends it as Morse to the speakers and/or an attached
sounder.
"""

# system modules
import sys
import pygame
import threading
import time
import datetime

# KOB modules
from kob import sender
from kob import display
from kob import sounder
from kob import newsreader

VERSION    = 'MorseMHC 1.3'
SOURCE     = 'url=http://home.comcast.net/~morsekob/rss/civilwar.xml'  # from web
#SOURCE     = 'file=civilwar.xml'  # get articles from 'data' folder
#SOURCE     = 'url=http://news.yahoo.com/rss/'  # Yahoo news (not yet supported)
#SOURCE     = None  # get input from keyboard
WPM        = 25    # overall code speed
CHARWPM    = 25    # character speed (Farnsworth)
N_ARTICLES = 3     # number of articles to read before repeating
ART_PAUSE  = 5.0   # pause between articles (sec)
GRP_PAUSE  = 20.0  # pause between article groups (sec)
TIMEOUT    = 60.0  # inactivity time in interactive mode for new form (sec)
WELCOME    = """Type a brief message on the keyboard to hear what it sounds like \
in American Morse code.  Compare the speed of the Morse code with familiar modern \
activities like texting, instant messaging, or writing an e-mail."""
DATEFORMAT = '%a, %d %b %Y %H:%M:%S %z'

print(VERSION)
pygame.mixer.init(frequency=22050, size=-16, channels=1, buffer=64)
pygame.init()
kobSender = sender.Sender(WPM, CHARWPM)
kobText = display.Display(VERSION)
kobSounder = sounder.Sounder()

def sendArticles():
    global running
    while running:
        kobNews = newsreader.Newsreader(SOURCE)
        if kobNews == None:
            print("Can't open news feed.")
            running = False
            break
        now = datetime.datetime.now(datetime.timezone.utc)
        while running:
            date, text = kobNews.getArticle()
            if date == None:
                break
            date = datetime.datetime.strptime(date, DATEFORMAT)
            if date < now:
                break
        for i in range(N_ARTICLES):
            if not running:
                break
            if text:
                kobText.newForm()
                time.sleep(1.0)
                sendText(text)
                time.sleep(ART_PAUSE)
            date, text = kobNews.getArticle()
        time.sleep(GRP_PAUSE - ART_PAUSE)

def sendText(text):
    for char in text:
        if not running:
            return
        char = char.upper()
        code = kobSender.encode(char)
        if code != []:
            kobSounder.sound(code)
        kobText.show(char)

sendArticlesThread = threading.Thread(target=sendArticles)
sendArticlesThread.daemon = True
running = True
if SOURCE:
    sendArticlesThread.start()

tLastInput = -sys.float_info.max  # time of last keyboard activity
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_ESCAPE:
                running = False
            elif SOURCE == None:
                char = event.unicode.upper()
                if char:
                    code = kobSender.encode(char)
                    kobText.show(char)
                    if code != []:
                        kobSounder.sound(code)
                    tLastInput = time.perf_counter()
    if SOURCE == None and time.perf_counter() > tLastInput + TIMEOUT:
        kobText = display.Display(VERSION)
        kobText.newForm()
        for c in WELCOME:
            kobText.show(c)
        kobText.show('\n')
        kobText.show('\n')
        tLastInput = sys.float_info.max
    time.sleep(0.010)
