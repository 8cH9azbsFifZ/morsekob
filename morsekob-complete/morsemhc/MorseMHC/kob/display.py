"""
Display module
"""

import os
import pygame
import ctypes

FULLSCREEN = True
SCREENSIZE = 900, 550  # window size (if not fullscreen)
PAGEWIDTH = 850  # width of page (pixels)

# MARGIN NEEDS TO BE CALCULATED FROM ACTUAL SCREENSIZE

PADDING = 50     # margins surrounding text within page
LINEWIDTH = 0.75 # fraction of page to fill before word wrapping
FONTSIZE   = 36  # font height in pixels
LINEPADDING = 15 # extra space between lines
FORMSPACING = 10 # blank space between forms
FOREGROUND = (32, 32, 32)  # text color (RGB)
BACKGROUND = (240, 220, 130)  # form color (RGB)
BLACK = (0, 0, 0)  # screen background

class Display:
    def __init__(self, caption):
        if FULLSCREEN:
            user32 = ctypes.windll.user32
            screensize = user32.GetSystemMetrics(0), user32.GetSystemMetrics(1)
            print('Screen size:', screensize)
            self.screen = pygame.display.set_mode(screensize, pygame.FULLSCREEN)
            self.screenWidth, self.screenHeight = screensize
            pygame.mouse.set_visible(False)
        else:
            self.screen = pygame.display.set_mode(SCREENSIZE)
            self.screenWidth, self.screenHeight = SCREENSIZE
        self.margin = int((self.screenWidth - PAGEWIDTH) / 2)
        self.lineWidth = int(LINEWIDTH * (self.screenWidth - 2 * self.margin) +
                self.margin)
        self.font = pygame.font.Font(None, FONTSIZE)
        self.x, self.y = self.margin + PADDING, PADDING
        self.lineHeight = FONTSIZE + LINEPADDING
        self.form = pygame.image.load(os.getcwd() + '\\data\\form.png'). \
                convert_alpha()
        pygame.display.set_caption(caption, 'KOB')
        self.screen.fill(BACKGROUND, pygame.Rect(self.margin, 0,
                self.screenWidth - 2 * self.margin, self.screenHeight))
        pygame.display.flip()

    def show(self, s):
        if s == '\r' or s == '\n':
            self.newLine(FONTSIZE + LINEPADDING)
            return
        text = self.font.render(s, True, FOREGROUND)
        if (self.x > self.lineWidth and s[0] == ' ' or
                self.x + text.get_width() + PADDING + self.margin >
                self.screenWidth):
            text = self.font.render(s.lstrip(), True, FOREGROUND)
            self.newLine(FONTSIZE + LINEPADDING)
        self.screen.blit(text, (self.x, self.y))
        self.x += text.get_width()
        self.lineHeight = text.get_height() + LINEPADDING
        pygame.display.flip()

    def newLine(self, lineHeight):
        self.x = self.margin + PADDING
        self.y += self.lineHeight
        self.lineHeight = lineHeight
        dy = (self.y + lineHeight) - (self.screenHeight - PADDING)
        if dy > 0:
            self.screen.scroll(0, -dy)
            self.screen.fill(BACKGROUND, pygame.Rect(self.margin,
                    self.screenHeight - dy,
                    self.screenWidth - 2 * self.margin, dy))
            self.y -= dy
            pygame.display.flip()

    def newForm(self):
        self.screen.scroll(0, -FORMSPACING)
        self.screen.fill(BLACK, pygame.Rect(
                self.margin, self.screenHeight - FORMSPACING,
                self.screenWidth - 2 * self.margin, FORMSPACING))
        self.y = self.screenHeight + PADDING
        self.lineHeight = 0
        self.newLine(self.form.get_height() + PADDING)
        self.screen.blit(self.form,
                ((self.screenWidth - self.form.get_width()) / 2, self.y))
        self.x = self.screenWidth
        pygame.display.flip()
