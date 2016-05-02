
#Used for creating the enemy
def Initialize(self):
    self._name = "Heavy enemy"
    self._health = 150
    self._damage = 25
    self._windup = True

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
    if self._windup == False:
        self._windup = True
        return self._damage
    else:
        print("The enemy is winding up!")
        self._windup = False
        return 0

#Called when the player attacks the enemy
def TakeDamage(self, _damage):
     self._health -= _damage
