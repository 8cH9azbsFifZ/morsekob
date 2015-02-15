"""
Sounder module
"""

import os
import pygame
import time
from kob import serialport

PORT = 'COM3'

class Sounder:
    def __init__(self):
        self.click = pygame.mixer.Sound(os.getcwd() + '\\data\\click.wav')
        self.clack = pygame.mixer.Sound(os.getcwd() + '\\data\\clack.wav')
        self.tLast = time.perf_counter()  # time of last click or clack
        self.port = serialport.SerialPort()
        self.port.portName = PORT
        self.port.openPort()
        self.latched = False  # true if circuit latched closed

    def sound(self, code):
        for c in code:
            if c < -3000:
                c = -500
            tNext = self.tLast + abs(c / 1000)
            t = time.perf_counter()
            dt = tNext - t
            if dt <= 0:
                self.tLast = t
            else:
                self.tLast = tNext
                time.sleep(dt)
            if c < 0 and not self.latched:
                self.port.setRTS(True)
                self.click.play(0)
            elif c == 1:  # latch circuit closed
                self.latched = True
                self.port.setRTS(True)
                self.click.play(0)
            elif c >= 2:
                self.latched = False
                self.port.setRTS(False)
                self.clack.play(0)

