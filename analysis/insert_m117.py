# coding=utf-8
from __future__ import absolute_import

import fileinput
import sys
import click


@click.command()
@click.argument("path", type=click.Path(exists=True))

def gcode_insert(path):

    for line in fileinput.input(path, inplace=1):
        if line.startswith(";LAYER:"):
            text = "M117 " + line.replace(';', '')
            print(line),
            print(text),
        else:
            print(line),