from System import Console
from System import Random

#Used for creating the weapon
def Initialize(self, level):
    rnd = Random()
    self._name = "TestArmor"
    self._health = rnd.Next(100,150) * level
    self._heal = rnd.Next(5,10) * level

def GetName(self):
    return self._name

def GetHealth(self):
    return self._health

def GetHealing(self):
    return self._heal

def Ability(self):
    Console.WriteLine("Your {0} heals you and you gain gain {1} health",self._name,self._heal)
    return self._heal