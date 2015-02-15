"""
Newsreader module
"""

import os
import urllib.request
import re

class Newsreader:
    def __init__(self, source):
        site, location = source.split('=', 1)
        if site == 'file':
            with open(os.getcwd() + '\\data\\' + location) as f:
                self.articles = re.findall('<item>.*?</item>',
                        f.read(), re.IGNORECASE+re.DOTALL)
        elif site == 'url':
            with urllib.request.urlopen(location) as f:
                self.articles = re.findall('<item>.*?</item>',
                        f.read().decode('utf-8'), re.IGNORECASE+re.DOTALL)
        else:
            return None
        self.artNo = -1

    def getArticle(self):
        self.artNo += 1
        if self.artNo >= len(self.articles):
            return None, None
        title, description, date = '', '', ''
        m = re.search('<title>(.*?)</title>',
                self.articles[self.artNo], re.IGNORECASE+re.DOTALL)
        if m:
            title = m.group(1)
        m = re.search('<description>(.*?)</description>',
                self.articles[self.artNo], re.IGNORECASE+re.DOTALL)
        if m:
            description = m.group(1)
        m = re.search('<pubDate>(.*?)</pubDate>',
                self.articles[self.artNo], re.IGNORECASE+re.DOTALL)
        if m:
            date = m.group(1)
        if title:
            text = title + ' = ' + description
        else:
            text = description
        text = re.sub('&lt;.*?&gt;', '', text, 0, re.IGNORECASE+re.DOTALL)
        text = re.sub('&amp;.*?;', ' ', text, 0, re.IGNORECASE+re.DOTALL)
        return date, text
