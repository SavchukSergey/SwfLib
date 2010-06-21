@echo off
FORFILES -m *.xml -c "cmd /c ..\References\swfmill\swfmill xml2swf @FILE @FNAME-compiled.swf"