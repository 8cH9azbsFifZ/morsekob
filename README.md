morsekob
========

This repository is just for development purposes -> OSX testing.

Further information: https://sites.google.com/site/morsekob/morsekob40. And
even this software is only in alpha status. If you want to use morsekob,
better go to [morsekob.org](http://www.morsekob.org).

The [requirements](https://sites.google.com/site/morsekob/morsekob40/requirements) describe the 
build process:


# Build
Installation of the dependencies
sudo apt-get install python-serial  # or python3-serial
sudo apt-get install python-pyaudio  # or python3-pyaudio, python-pyaudio:i386...

on OSX: 
port install py-serial
port install py-pyaudio


cd PyKOB
sudo python setup.py install

Verification of the installation:
sudo port select python python27
   --> osx: python2.7 -m pykob.syscheck
python -m pykob.syscheck




# Applications
The [applications](https://sites.google.com/site/morsekob/morsekob40/downloads) are under Applications

PYTHONPATH=$PYTHONPATH:/Library/Python/2.7/site-packages/ python2.7 Sample.py 

Examples with working audio callbacl... http://people.csail.mit.edu/hubert/pyaudio/


# Server installation

The [requirements](https://sites.google.com/site/morsekob/server/requirements).

The [server software](https://sites.google.com/site/morsekob/server/software) resides now in the
directory Server.


Code Quality
============
This is experimental code.


