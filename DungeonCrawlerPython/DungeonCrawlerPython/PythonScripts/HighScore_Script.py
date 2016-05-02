import sqlite3 as lite
import sys
con = lite.connect('Highscore.db') # Opretter filen, hvis den ikke eksisterer
cur = con.cursor() # Opretter en cursor
# Herefter oprettes tabellen, der indsaettes figurer
cur.execute("CREATE TABLE if not exists Spiller(Id INTEGER PRIMARY KEY, Name TEXT, Score int, Time TEXT)")

def Add(name,score,time):
    with con:       
        cur.execute("INSERT INTO Spiller (Id,name,score,time) VALUES(NULL,?,?,?)",(name,score,time))