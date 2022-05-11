from datetime import datetime
import arborescence
import os

def idxInDayDir(date = datetime.now(), mode = "A"):
    path = arborescence.getPath(date=date, mode=mode)
    idx = len(os.listdir(path=path))
    return '%04d' % idx

def nameTime(date = datetime.now()):
    return date.strftime("%Y_%m_%d_%H_%M_%S")

def addBmpExtension(str):
    return str + ".bmp"

def addMode(str, mode = "A"):
    return mode + "_" + str

def addIdx(str, date = datetime.now(), mode = "A"):
    return str + "__" + idxInDayDir(date=date, mode=mode)

def getNameFile(date = datetime.now(), mode = "A"):
    name = nameTime(date)
    name = addIdx(name, date, mode)
    name = addBmpExtension(name)
    name = addMode(name, mode)
    return name
