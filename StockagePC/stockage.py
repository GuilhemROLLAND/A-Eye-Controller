from datetime import datetime
import shutil
import arborescence
import naming


def placeImage(img, date=datetime.now(), mode="A"):
    shutil.copyfile(img, arborescence.getPath(date=date, mode=mode) +
                    "/" + naming.getNameFile(mode=mode, date=date))
