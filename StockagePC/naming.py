from datetime import datetime

def nameTime(date = datetime.now()):
    return date.strftime("%Y_%m_%d_%H_%M_%S")

def addBmpExtension(str):
    return str + ".bmp"

def addMode(str, mode = "A"):
    return mode + "_" + str

def getNameFile(date = datetime.now(), mode = "A"):
    name = nameTime(date)
    name = addBmpExtension(name)
    name = addMode(name, mode)
    return name
