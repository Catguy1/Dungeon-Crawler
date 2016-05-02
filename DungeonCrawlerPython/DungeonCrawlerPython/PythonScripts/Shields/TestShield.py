from System import Console
from System import Random

#Used for creating the weapon
def Initialize(self, damage):
    rnd = Random()
    self._name = "TestShield"
    self._block = rnd.Next(5,15)

def GetName(self):
    return self._name

def GetBlock(self):
    return self._block

def Block(self, damage):
    Console.WriteLine("You defend yourself with your {0}, it blocks {1} damage",self._name,self._block)

    if(self._block < damage):
        return damage - self._block
    else:
        return 0
        