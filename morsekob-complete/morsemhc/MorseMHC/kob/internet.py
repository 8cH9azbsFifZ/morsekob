"""
Internet module
"""

import socket
import struct
import threading
from time import sleep

SERVER = 'mtc-kob.dyndns.org'
PORT = 7890

DIS = 2  # Disconnect
DAT = 3  # Code or ID
CON = 4  # Connect
ACK = 5  # Ack

shortPacketFormat = struct.Struct('<hh')  # cmd, wire
idPacketFormat = struct.Struct('<hh 128s 4x i 12x 204x i 128s 8x')  # cmd, len, id, seq, n, ver
codePacketFormat = struct.Struct('<4x 128s 4x i 12x 51i i 128x 8x')  # id, seq, code list, n

NUL = '\x00'

class Internet:
    def __init__(self, version):
        self.socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        self.address = SERVER, PORT
        self.version = version.encode(encoding='ascii')
        self.officeID = ''.encode(encoding='ascii')
        self.wireNo = 0
        self.sentSeqNo = 0
        self.rcvdSeqNo = -1
        self.connecting = False

    def connect(self, officeID, wireNo):
        self.officeID = officeID.encode(encoding='ascii')
        self.wireNo = wireNo
        self.connecting = True
        keepAliveThread = threading.Thread(target=self.keepAlive)
        keepAliveThread.daemon = True
        keepAliveThread.start()

    def disconnect(self):
        self.connecting = False
        sleep(0.5)
        shortPacket = shortPacketFormat.pack(DIS, 0)
        self.socket.sendto(shortPacket, self.address)

    def keepAlive(self):
        while self.connecting:
            shortPacket = shortPacketFormat.pack(CON, self.wireNo)
            self.socket.sendto(shortPacket, self.address)
            self.sentSeqNo += 2
            idPacket = idPacketFormat.pack(DAT, 492, self.officeID,
                    self.sentSeqNo, 0, self.version)
            self.socket.sendto(idPacket, self.address)
            print('Keepalive sent')
            sleep(10.0)  # send another keepalive sequence every ten seconds

    def read(self):
        while True:
            buf = self.socket.recv(500)
            nBytes = len(buf)
            if nBytes == 2:
                pass  # ignore Ack packet
            elif nBytes == 496:  # code or ID packet
                stnID, seqNo, *code = codePacketFormat.unpack(buf)
                stnID, sep, fill = stnID.decode(encoding='ascii').partition(NUL)
                n = code[51]
                if n > 0 and seqNo != self.rcvdSeqNo:  # code packet
                    self.rcvdSeqNo = seqNo
                    return code[:n]
            else:  # invalid record length
                pass
