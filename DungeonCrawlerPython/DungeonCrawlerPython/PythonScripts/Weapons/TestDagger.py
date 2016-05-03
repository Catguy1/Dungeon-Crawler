from System import Console
from System import Random

#Used for creating the weapon
def Initialize(self, damage):
    self._rnd = Random()
    self._name = "TestDagger"
    self._damage = self._rnd.Next(5,15)
    self._hitChance = 33

def GetName(self):
    return self._name

def GetDamage(self):
    return self._damage

def Attack(self):
    returnDamage = 0
    for x in range(2):
        if(self._rnd.Next(101) < self._hitChance):
            Console.WriteLine("You swing your {0} and deal {1} damage",self._name,self._damage)
            returnDamage += self._damage
        else:
            Console.WriteLine("You swing and you miss")

    return returnDamage