import json
import csv
import os

rootDir = "D:\\Ashirbad\\Unity_Projects\\motionParallaxFinal"
folderPath = "subjectTrials"
subjectName = "TaranjitKaur_True_04-December-2021"
responseFile = "response_sheet.csv"
trialNo = 10
extension = ".json"
jsonFile = "TaranjitKaur"+"_"+str(trialNo)+"_"+extension
targetFile = os.path.join(rootDir,folderPath,subjectName,jsonFile)
destFile = os.path.join(rootDir,folderPath,subjectName,responseFile)

with open(targetFile) as json_file:
    data = json.load(json_file)
print(data.values())

# field_names = ['trialNo','userAnswer','actualAnswer']

# with open(destFile,'a') as f_object:

dataFile = open(destFile,'a')
csv_writer = csv.writer(dataFile)
csv_writer.writerow(data.values())
dataFile.close()


