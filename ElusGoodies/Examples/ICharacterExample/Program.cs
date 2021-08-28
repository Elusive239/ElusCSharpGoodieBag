using System;
using ElusGoodies;

namespace ICharacterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Character c = new Character(4, 4, 4, 4, Team.Player , "11");
            Character s = new Character(4, 4, 4, 4, Team.Enemy1 , "12");

            while(c.isDead == s.isDead){
                c.Attack(s);
                s.Attack(c);

                if(c.isDead || s.isDead) break;
            }
        }
    }
    class Character : ICharacter{
        public int health { get; set;}
        int hp;
        public string charName {get; set;}
        int END, STR, AGI, INT;
        public Team team{get; set;}
        bool canDoStuff = true;

        public Character(int _END, int _STR, int _AGI, int _INT, Team _team, string _charName){
            END = _END;
            STR = _STR;
            AGI = _AGI;
            INT = _INT;
            team = _team;
            charName = _charName;

            health = END*2 + 4;
        }
        
        public bool Attack(ICharacter target){
            if(target.GetStat(4) == Convert.ToInt32(team) || isDead) return false;

            target.health -= STR;
            if(target.health <= 0)
                target.Die(this);
            return true;
        }
        public void Die(ICharacter killer){
            Console.WriteLine(charName +" killed "+killer.charName+"!");
        }
        /// <summary>
        /// Should return one of the stats at the given ID. assumes that your 
        /// RPG game would have stats to returns
        /// </summary>
        /// <param name="statId"></param>
        /// <returns></returns>
        public int GetStat(int statId){
            switch (statId)
            {
                case 0: return END;
                case 1: return STR;
                case 2: return AGI;
                case 3: return INT;
                case 4: return Convert.ToInt32(team);
                case 5: return health;
                default: return 0;
            }
        }
        public void SetStat(int statId, int value){
            switch (statId){
                case 0: END = value; break;
                case 1: STR = value; break;
                case 2: AGI = value; break;
                case 3: INT = value; break;
                case 4: team = (Team) value ; break;
                case 5: health = value; break;
            }
        }
        public bool isDead { get {return health <= 0;} }
        public bool canMove{get {return canDoStuff || isDead;}}
    }
}
