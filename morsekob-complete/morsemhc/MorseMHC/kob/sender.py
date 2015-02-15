"""
Code reader module
"""

import os

DOTSPERWORD = 45;    # dot units per word, including all spaces
                     #   (MORSE is 43, PARIS is 47)
CHARSPACING = True   # add Farnsworth spacing between all characters
WORDSPACING = False  # add Farnsworth spacing only between words
CODETYPE = 0         # 0 = American, 1 = International

f = open(os.getcwd() + '\\data\\codetable.txt')
f.readline()  # ignore first line
CODETABLE = {}
while True:
    s = f.readline()
    if s == '':
        break
    a, t, c = s.rstrip().partition('\t')
    CODETABLE[a] = c
f.close()

class Sender:
    def __init__(self, wpm, cwpm):
        cwpm = max(wpm, cwpm)
        self.dotLen    = int(1200 / cwpm)  # dot length (ms)
        self.charSpace = 3 * self.dotLen  # space between characters (ms)
        self.wordSpace = int((self.charSpace * 7) / 3)  # space between words
        if CODETYPE == 0:  # American
            self.charSpace += int((60000 / cwpm - self.dotLen *
                    DOTSPERWORD) / 6)
            self.wordSpace = 2 * self.charSpace
        else:   # International
            self.wordSpace = int((self.charSpace * 7) / 3)
        delta = 60000 / wpm - 60000 / cwpm  # amount to stretch each word
        if CHARSPACING:
            self.charSpace += int(delta / 6)
            self.wordSpace += int(delta / 3)
        elif WORDSPACING:
            self.wordSpace += int(delta)
        self.space = self.wordSpace  # delay before next code element (ms)
        
    def encode(self, c):
        c = c.upper()
        code = []
        if not c in CODETABLE:
            if c == '\'' or c == '’':
                self.space += int((self.wordSpace - self.charSpace) / 2)
            else:
                self.space += self.wordSpace - self.charSpace
        else:
            for e in CODETABLE[c]:
                if e == ' ':
                    self.space = 3 * self.dotLen
                else:
                    code.append(-self.space)
                    if e == '.':
                        code.append(self.dotLen)
                    elif e == '-':
                        code.append(3 * self.dotLen)
                    elif e == '=':
                        code.append(6 * self.dotLen)
                    elif e == '#':
                        code.append(9 * self.dotLen)
                    self.space = self.dotLen
            self.space = self.charSpace
        return code
