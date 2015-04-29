morsekob
========

This is an implementation of [MOIP](https://github.com/8cH9azbsFifZ/moip).

Scope of this repository
========================
This repository is just for development purposes -> OSX testing.
Further information: https://sites.google.com/site/morsekob/morsekob40. And
even this software is only in alpha status. If you want to use morsekob,
better go to [morsekob.org](http://www.morsekob.org).

# Building
The [requirements](https://sites.google.com/site/morsekob/morsekob40/requirements) describe the 
build process. At first: installation of the dependencies.

### on Linux:
sudo apt-get install python-serial  # or python3-serial
sudo apt-get install python-pyaudio  # or python3-pyaudio, python-pyaudio:i386...

### on OSX: 
port install py-serial
port install py-pyaudio

Installation of the code:

cd PyKOB
sudo python setup.py install

Verification of the installation:
sudo port select python python27
   --> osx: python2.7 -m pykob.syscheck
python -m pykob.syscheck


# Applications
The [applications](https://sites.google.com/site/morsekob/morsekob40/downloads) are under Applications

PYTHONPATH=$PYTHONPATH:/Library/Python/2.7/site-packages/ python2.7 Sample.py 
Alternatively:
python Time.py c 33 "ok" 


# Server installation

The [requirements](https://sites.google.com/site/morsekob/server/requirements).

The [server software](https://sites.google.com/site/morsekob/server/software) resides now in the
directory Server.

Uninstalling
============
On raspi:
sudo rm -rf /usr/local/lib/python2.7/dist-packages/pykob
sudo rm -rf /usr/local/lib/python2.7/dist-packages/PyKOB-1.0.0.egg-info


Code Quality
============
This is experimental code.



