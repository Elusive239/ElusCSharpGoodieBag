using System;

namespace ElusGoodies
{
    public enum Team
    {
        Player, Enemy1, Enemy2, Enemy3, Nuetral
    }
    public interface ICharacter{
        int health { get; set; }
        string charName {get; set;}
        Team team { get; set; }
        bool Attack(ICharacter target);
        void Die(ICharacter killer);
        /// <summary>
        /// Should return one of the stats at the given ID. assumes that your 
        /// RPG game would have stats to returns
        /// </summary>
        /// <param name="statId"></param>
        /// <returns></returns>
        int GetStat(int statId);
        void SetStat(int statId, int value);
        bool isDead { get; }
        bool canMove{get;}
    }
}