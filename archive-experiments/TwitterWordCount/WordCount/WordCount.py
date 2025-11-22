# -*- coding: utf-8 -*-
"""
Created on Fri Dec 18 09:20:44 2020

@author: Nathaniel Carballo
"""

# allows for importing csv to pull data from
import pandas as pd
# library to implement tf-idf
from sklearn.feature_extraction.text import TfidfVectorizer

# initializing program
if __name__=="__main__":
    textData = (pd.read_csv("Tweets.csv")  # pulling only text data from
                ["text"]                   # from Tweets.csv and ignoring all N/A fields
                .dropna()                  # and assign them to textData variable
                .tolist())

# this will allow for easy and quick tf-idf implementation through library vectorizer
tfIdfVectorizer = TfidfVectorizer(use_idf=True)
# implementing fit_transform to gather data from textData and compute tf-idf using
# that data
x = tfIdfVectorizer.fit_transform(textData)

# places the tf-idf results into a dataframe for exporting to csv
df_tfidf = pd.DataFrame(x[1].T.todense(), index=tfIdfVectorizer.get_feature_names(), columns=["TF-IDF"])
df = df_tfidf.sort_values('TF-IDF', ascending=False)


# writing tf-idf dataframe seperate file called for backup storage
df.to_csv('tf-idf_Tweets.csv', encoding = 'utf-8', index=False)
# appending tf-idf dataframe to original Tweets.csv
df.to_csv('Tweets.csv', mode='a', header=False)
# printing tf-idf dataframe to terminal to signal when task is completed.
print(df)