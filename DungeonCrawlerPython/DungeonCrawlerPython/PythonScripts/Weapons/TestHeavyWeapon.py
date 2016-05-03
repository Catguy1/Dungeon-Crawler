from System import Console
from System import Random

#Used for creating the weapon
def Initialize(self, level):
    rnd = Random()
    self._windup = False
    self._name = "Hammer"
    self._damage = rnd.Next(20,50) * level

def GetName(self):
    return self._name

def GetDamage(self):
    return self._damage

def Attack(self):
    if(self._windup):
        Console.WriteLine("You swing your {0} and deal {1} damage",self._name,self._damage)
        self._windup = False
        return self._damage
    else:
        self._windup = True
        Console.WriteLine("You ready your {0}", self._name)
        return 0