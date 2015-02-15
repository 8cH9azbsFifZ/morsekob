"""
SerialPort module
"""

import ctypes
from ctypes import windll

SETRTS = 3
CLRRTS = 4
SETDTR = 5
CLRDTR = 6
MS_CTS_ON = 0x10
MS_DSR_ON = 0x20
GENERIC_READ = 0x80000000
GENERIC_WRITE = 0x40000000
OPEN_EXISTING = 3
FILE_ATTRIBUTE_NORMAL = 0x80

class SerialPort:
    def __init__(self):
        self.portName = '';
        self.hSerialPort = -1

    def openPort(self):
        SerialPort.closePort(self)
        if self.portName != 'None' and self.portName != '':
            self.hSerialPort = windll.kernel32.CreateFileW(self.portName,
                    GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING,
                    FILE_ATTRIBUTE_NORMAL, 0)
            if self.hSerialPort == -1:
                print('Unable to open serial port', self.portName, '- Error',
                        windll.kernel32.GetLastError())

    def closePort(self):
        if self.hSerialPort != -1:
            if not windll.kernel32.CloseHandle(self.hSerialPort):
                print('Unable to close serial port - Error',
                        windll.kernel32.GetLastError())
            self.hSerialPort = -1

    def setRTS(self, value):
        if self.hSerialPort != -1:
            ms = SETRTS if value else CLRRTS
            if not windll.kernel32.EscapeCommFunction(self.hSerialPort, ms):
                print('Can\'t set RTS - Error', windll.kernel32.GetLastError())

    def getCTS(self):
        ms = ctypes.c_int(0)
        if self.hSerialPort != -1:
            if not windll.kernel32.GetCommModemStatus(self.hSerialPort,
                    ctypes.byref(ms)):
                print('Can\'t get CTS - Error', windll.kernel32.GetLastError())
                return False
            else:
                return (ms.value & MS_CTS_ON) == MS_CTS_ON
        else:
            return False

    def setDTR(self, value):
        if self.hSerialPort != -1:
            ms = SETDTR if value else CLRDTR
            if not windll.kernel32.EscapeCommFunction(self.hSerialPort, ms):
                print('Can\'t set DTR - Error', windll.kernel32.GetLastError())

    def getDSR(self):
        ms = ctypes.c_int(0)
        if self.hSerialPort != -1:
            if not windll.kernel32.GetCommModemStatus(self.hSerialPort,
                    ctypes.byref(ms)):
                print('Can\'t get DSR - Error', windll.kernel32.GetLastError())
                return False
            else:
                return (ms.value & MS_DSR_ON) == MS_DSR_ON
        else:
            return False
