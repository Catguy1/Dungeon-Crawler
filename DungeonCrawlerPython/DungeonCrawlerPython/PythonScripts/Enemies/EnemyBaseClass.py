
#Used for creating the enemy
def Initialize(self):
    self._name = "Generic enemy"
    self._health = 100
    self._damage = 10

#Gets the name of the enemy
def GetName(self):
    return self._name

#Gets the enemy's damage
def GetDamage(self):
    return self._damage

#Gets the health of the enemy
def GetHealth(self):
    return self._health

#Attack function called during the enemy's turn during the combat phase
def Attack(self):
    return self._damage 

#Called when the player attacks the enemy
def TakeDamage(self, _damage):
     self._health -= _damage
