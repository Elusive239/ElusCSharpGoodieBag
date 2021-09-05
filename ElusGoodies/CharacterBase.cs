using System;

namespace ElusGoodies
{
    public abstract class CharacterBase : IComparable<CharacterBase>{
        int health, maxHealth;
        public int tempDamage = 0;
        public int Health {get {return health - tempDamage;}}
        string name;
        public string Name {get;}

        public CharacterBase(string _name, int _health){
            name = _name;
            health = _health;
            maxHealth = _health;
        }

        /// <summary>
        /// Sets the max health
        /// </summary>
        /// <param name="amount"></param>
        public virtual void SetMaxHealth(int amount){
            maxHealth = amount;
        }

        /// <summary>
        /// When called adds "amount" of health to remaining health.
        /// health cannot exceed characters max health.
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Heal(int amount){
            health = Math.Clamp(health + amount, 0, maxHealth);
        }

        /// <summary>
        /// When called, removes "amount" of health from remaining health.
        /// When health reaches zero, it calls the Die method and returns true.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public virtual bool Damage(int amount, bool temporary){
            if(!temporary)
                health = Math.Clamp(health - amount, 0, maxHealth);
            else tempDamage += amount;

            if(Health == 0){
                Die();
                return true;
            }
            return false;
        }

        public abstract void Attack(CharacterBase target);
        public abstract void UseItem(CharacterBase target);
        public abstract void Wait();
    }
}