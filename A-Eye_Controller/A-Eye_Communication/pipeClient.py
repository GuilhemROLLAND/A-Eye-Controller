## If set to True, no pipe used --> STDOUT
DEBUG = False

def writeInPipe(msg):
    """
    Write the string in the pipe called CSServer, firstly opened by Controller.
    
    Args:
        msg: the string to write.
    """
    if DEBUG:
        print(msg)
    else:
        with open(r'\\.\pipe\\'+'CSServer', 'w') as f:
            f.write(msg + "\n")
    return
