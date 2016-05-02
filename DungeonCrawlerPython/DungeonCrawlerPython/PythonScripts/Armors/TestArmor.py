from System import Console
from System import Random

#Used for creating the weapon
def Initialize(self, health):
    rnd = Random()
    self._name = "TestArmor"
    self._health = rnd.Next(100,250)
    self._heal = 5

def GetName(self):
    return self._name

def GetHealth(self):
    return self._health

def Ability(self):
    Console.WriteLine("Your {0} heals you and you gain gain {1} health",self._name,self._heal)
    return self._heal