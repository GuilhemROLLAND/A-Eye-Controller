from datetime import date, datetime
import os

def create_arborescence(newpath):
    if not os.path.exists(newpath):
        os.makedirs(newpath)

def getPath(date = date.today()):
    newpath = "./images/" +  date.strftime("%Y") + "/" + date.strftime("%m") + "/" + date.strftime("%d")
    create_arborescence(newpath)
    return newpath

