from datetime import date, datetime, timedelta
from time import time
import arborescence
import naming 
import stockage

testArbo = True
testNaming = True
testStockage = True

# Test arborescence
if testArbo:
    print(arborescence.getPath(date.today()))
    print(arborescence.getPath(date.today() - timedelta(days=1)))
    print(arborescence.getPath(date.today() - timedelta(days=30)))
    print(arborescence.getPath(date.today() - timedelta(days=365)))

# Test naming
if testNaming:
    print(naming.getNameFile(datetime.now()))
    print(naming.getNameFile(datetime.now() - timedelta(seconds=30)))
    print(naming.getNameFile(datetime.now(), "M"))
      
# Test Stockage
if testStockage:
    stockage.placeImage("StockagePC/pict.bmp")
    stockage.placeImage("StockagePC/pict.bmp", date = date.today() - timedelta(days=30))
    stockage.placeImage("StockagePC/pict.bmp", mode="M")
    