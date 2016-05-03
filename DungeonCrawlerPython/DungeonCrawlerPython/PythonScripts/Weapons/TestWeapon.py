from System import Console
from System import Random
#Used for creating the weapon
def Initialize(self, damage):
    rnd = Random()
    self._name = "TestSword"
    self._damage = rnd.Next(5,15)

def GetName(self):
    return self._name

def GetDamage(self):
    return self._damage

def Attack(self):
    Console.WriteLine("You swing your {0} and deal {1} damage",self._name,self._damage)
    return self._damage