import argparse
import stockage


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("-f", "--file", type=str,required=True, help="name of the file")
    args = parser.parse_args()
    stockage.placeImage(args.file)
