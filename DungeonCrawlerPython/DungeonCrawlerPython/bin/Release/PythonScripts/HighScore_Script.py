import sqlite3 as lite
from System import Console
import sys
con = lite.connect('Highscore.db') # Opretter filen, hvis den ikke eksisterer
cur = con.cursor() # Opretter en cursor
# Herefter oprettes tabellen, der indsaettes figurer
cur.execute("CREATE TABLE IF NOT EXISTS SPILLER(ID INTEGER PRIMARY KEY, NAME TEXT, SCORE int, TIME TEXT)")

def Add(name,score,time):
    try:
        with con:       
            cur.execute("INSERT INTO SPILLER (Id,name,score,time) VALUES(NULL,?,?,?)",(name,score,time))
    except:
        Console.WriteLine("Failed to add player to the highscore database")

def Read():
    try:
        with con:
            cur.execute("SELECT * FROM SPILLER ORDER BY SCORE DESC") # Indholdet hentes
            rows=cur.fetchall() # resultatet gemmes i variablen rows
            for row in rows:
                Console.WriteLine(row)
    except:
        Console.WriteLine("Failed to get highscores from database")