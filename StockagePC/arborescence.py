from datetime import date, datetime
import os

def create_arborescence(newpath):
    if not os.path.exists(newpath):
        os.makedirs(newpath)

def getPath(date = date.today(), mode = "A"):
    newpath = "./images/" +  date.strftime("%Y") + "/" + date.strftime("%m") + "/" + date.strftime("%d")
    if (mode == "M"):
        newpath = newpath + "/Manual"
    else :
        newpath = newpath + "/Auto"
    create_arborescence(newpath)
    return newpath

