#!/usr/bin/env python3
import os

if __name__ == "__main__":
    # 
    cmd1 = 'dotnet ./ExportFairyGUICode/ExportFairyGUICode.dll --cmd=generatecode --optionSetting=./ExportSetting.json'
    cmd2 = 'dotnet ./Copy/Copy.dll --setting=./CopyClientSetting.json'
    cmd3 = 'dotnet ./GenerateFguiResPackageConfig/GenerateFguiResPackageConfig.dll --optionSetting=./ResPackageConfig.json'
    pathCmd = 'cd ' + os.path.dirname(__file__) + ';'
    os.system(pathCmd+cmd1)
    os.system(pathCmd+cmd2)
    os.system(pathCmd+cmd3)


