"""
Code reader module
"""

import os, sys

DOTVSDASH       = 1.7  # dot vs dash
DASHVSLONGDASH  = 4.5  # T vs L
##LONGVSCLOSE     = 12.0 # L vs line closure
BETWEENDOTS     = 1.7  # space between dots
##BETWEENELEMENTS = 2.7  # space between other elements
TOLERANCE       = 1.05 # tolerance for two spaces to be "equal"
##DECODEINTERVAL = 20    # wait time to force decode (dot units)
##LONGTIME        = sys.float_info.max
MINSPACE        = 2.0  # space (in dots) represented by no space between displayed characters
SPACEPERDOT     = 0.5  # space (in dots) represented by each additional space between displayed characters
MAXSPACE        = 6    # maximum number of spaces between displayed characters

f = open(os.getcwd() + '\\codetable.txt')
f.readline()  # ignore first line
CODETABLE = {}
while True:
    s = f.readline()
    if s == '':
        break
    a, t, c = s.rstrip().partition('\t')
    CODETABLE[c] = a
f.close()

class Reader:
    def __init__(self, wpm):
        self.dotLen    = 1200 / wpm  # dot length (ms)
        self.currSpace = 0   # space before current character
        self.currCode  = ''  # code elements for current character
        self.currMark  = 0   # length of last dot or dash in current character
        self.prevSpace = 0   # space before previous character
        self.prevCode  = ''  # code elements for previous character
        self.prevMark  = 0   # length of last dot or dash in previous character
        self.latched   = False # true if circuit latched closed

    def decode(self, code, printCallback):
        for c in code:
            if c < 0 and not self.latched:
                sp = abs(c)
                if sp > BETWEENDOTS * self.dotLen:
                    codePair = self.prevCode + ' ' + self.currCode
                    if self.prevSpace > self.currSpace * TOLERANCE and \
                        self.currSpace * TOLERANCE < sp and \
                        codePair in CODETABLE and \
                        codePair != '. ...':
                        printCallback(self.decodeChar(self.prevSpace, codePair, 0))
                        self.currCode = ''
                    else:
                        printCallback(self.decodeChar(self.prevSpace, self.prevCode, self.prevMark))
                    self.prevSpace = self.currSpace
                    self.prevCode = self.currCode
                    self.prevMark = self.currMark
                    self.currSpace = sp
                    self.currCode = ''
                    self.currMark = 0
##            elif c == 1:  # latch in mark state
##                self.latched = True
            elif c > 2 or self.latched:
                mk = abs(c)
                if mk < DOTVSDASH * self.dotLen:
                    self.currCode += '.'
                else:
                    self.currCode += '-'
                self.currMark = mk;
                self.latched = False
 
    def decodeChar(self, space, codeString, mark):
        if codeString == '':
            return ''
        if codeString in CODETABLE:
            s = CODETABLE[codeString]
        else:
            s = str(codeString)
        if s == 'T' and mark > DASHVSLONGDASH * self.dotLen:
            s = 'L'
        n = min(max(int((space / self.dotLen - MINSPACE) * SPACEPERDOT
                + 0.5), 0), MAXSPACE)
        return n * ' ' + s
