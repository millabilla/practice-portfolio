
"""
Created on Sat Jul 25 15:58:24 2020
Web Scraper
@author: mille
tutorial code: https://towardsdatascience.com/web-scraping-in-5-minutes-1caceca13b6c
"""

#Importing libraries that we'll need to use
import requests
from bs4 import BeautifulSoup
from tqdm import tqdm_notebook
import re
import pandas as pd

#define function for exracting data
def ExtractDataFromRequest(data):
	dictData={}
	for book in data.find_all('div', attrs={'class':'cmp-text text'}):
		try:
			text=book.text
			pattern=re.compile(r'(?<=\d\.).+(?=\n)')#regular expression that will parse the data retrieved from penguin website
			datarow=re.findall(pattern,text)[0].split(' by')
			if(len(datarow)>1):
				key,val=datarow[0],datarow[1]
				dictData[key]=val
		except:
			None
	return dictData	
		
url="https://www.penguin.co.uk/articles/2018/100-must-read-classic-books/"
siteRequest=requests.get(url)
soup=BeautifulSoup(siteRequest.text,'html.parser')
formattedData=ExtractDataFromRequest(soup)
openFile=open('bookdata.txt','w')
for title in formattedData:
		openFile.write(str(title)+" by "+str(formattedData[title])+"\n")
