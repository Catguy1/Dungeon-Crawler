from System import Console
#Used for creating the enemy
def Initialize(self, level):
    self._name = "Generic enemy"
    self._health = 100 * level
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
    Console.WriteLine("The enemy attacks for {0} damage", self._damage)
    return self._damage 

#Called when the player attacks the enemy
def TakeDamage(self, _damage):
     self._health -= _damage
