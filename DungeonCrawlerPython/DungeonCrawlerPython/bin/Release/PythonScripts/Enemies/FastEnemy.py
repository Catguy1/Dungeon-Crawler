from System import Console
from System import Random
#Used for creating the enemy
def Initialize(self, level):
    self._rnd = Random()
    self._hitChance = 50
    self._name = "Fast enemy"
    self._health = 50 * level
    self._damage = 10 * level
    self._exp = 15 * level

#Gets the name of the enemy
def GetName(self):
    return self._name

#Gets the enemy's damage
def GetDamage(self):
    return self._damage

#Gets the health of the enemy
def GetHealth(self):
    return self._health

#Gets the exp of the enemy
def GetExp(self):
    return self._exp

#Attack function called during the enemy's turn during the combat phase
def Attack(self):
    returnDamage = 0

    for x in range(2):
        if(self._rnd.Next(100) < self._hitChance):
            Console.WriteLine("The enemy attacks for {0} damage", self._damage)
            returnDamage += self._damage 
        else:
           Console.WriteLine("The enemy misses")

    return returnDamage


#Called when the player attacks the enemy
def TakeDamage(self, _damage):
     self._health -= _damage
