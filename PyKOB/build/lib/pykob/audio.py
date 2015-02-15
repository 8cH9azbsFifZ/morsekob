"""

audio module

Provides audio for simulated sounder.

"""

import os
import wave
from pykob import log
import time
import sys
try:
    import pyaudio
    ok = True
except:
    log.log('PyAudio not installed.')
    ok = False

BUFFERSIZE = 16

nFrames = [0, 0]
frames = [None, None]
nullFrames = None
iFrame = [0, 0]
sound = 0
if ok:
    pa = pyaudio.PyAudio()
    filename = ['clack48.wav', 'click48.wav']
    path = os.path.dirname(os.path.abspath(__file__))
    for i in range(2):
        fn = os.path.join(path, filename[i])
        f = wave.open(fn, mode='rb')
        print "reading"
        print fn
        nChannels = f.getnchannels()
        sampleWidth = f.getsampwidth()
        sampleFormat = pa.get_format_from_width(sampleWidth)
        frameWidth = nChannels * sampleWidth
        frameRate = f.getframerate()
        nFrames[i] = f.getnframes()
        frames[i] = f.readframes(nFrames[i])
        iFrame[i] = nFrames[i]
        f.close()
    nullFrames = bytes(frameWidth*BUFFERSIZE)

def play(snd):
    print "play"
    print snd
    global sound
    sound = snd
    iFrame[sound] = 0


def callback(in_data, frame_count, time_info, status_flags):
    if frame_count != BUFFERSIZE:
        log.log('Unexpected frame count request from PyAudio:', frame_count)
    if iFrame[sound] + frame_count < nFrames[sound]:
        startByte = iFrame[sound] * frameWidth
        endByte = (iFrame[sound] + frame_count) * frameWidth
        outData = frames[sound][startByte:endByte]
        iFrame[sound] += frame_count
        return (outData, pyaudio.paContinue)
    else:
        return(nullFrames, pyaudio.paContinue)


if ok:
    apiInfo = pa.get_default_host_api_info()
    apiName = apiInfo['name']
    devIdx = apiInfo['defaultOutputDevice']
    devInfo = pa.get_device_info_by_index(devIdx)
    devName = devInfo['name']
    strm = pa.open(rate=frameRate, channels=nChannels, format=sampleFormat,
            output=True, frames_per_buffer=BUFFERSIZE,
            stream_callback=callback)
##            output=True, output_device_index=devIdx, frames_per_buffer=BUFFERSIZE,
##            stream_callback=callback)
    strm.start_stream()
##    print('PyAudio latency: {0:.0f} ms'.format(strm.get_output_latency()*1000))

##strm.stop_stream()
##strm.close()
##pa.terminate()
import pyaudio
import wave
import sys


CHUNK = 1024
def play_click():
    wf = wave.open("/Library/Python/2.7/site-packages/pykob/click48.wav", 'rb')
    p = pyaudio.PyAudio()
    stream = p.open(format=p.get_format_from_width(wf.getsampwidth()), channels=wf.getnchannels(), rate=wf.getframerate(), output=True)
    data = wf.readframes(CHUNK)
    while data != '':
        stream.write(data)
        data = wf.readframes(CHUNK)
    stream.stop_stream()
    stream.close()
    print "click in audio"
    p.terminate()

def play_clack():
    wf = wave.open("/Library/Python/2.7/site-packages/pykob/clack48.wav", 'rb')
    p = pyaudio.PyAudio()
    stream = p.open(format=p.get_format_from_width(wf.getsampwidth()), channels=wf.getnchannels(), rate=wf.getframerate(), output=True)
    data = wf.readframes(CHUNK)
    while data != '':
        stream.write(data)
        data = wf.readframes(CHUNK)
    stream.stop_stream()
    stream.close()
    p.terminate()
