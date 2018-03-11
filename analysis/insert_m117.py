import fileinput
import sys

for line in fileinput.input(str(sys.argv[1]), inplace=1):
    if line.startswith(";LAYER:"):
        text = "M117 " + line.replace(';', '')
        print(line)
        print(text),
    else:
        print(line),
