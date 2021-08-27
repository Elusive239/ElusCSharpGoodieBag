using System;
namespace ElusGoodies
{
    public enum Team
    {
        Player, Enemy1, Enemy2, Enemy3, Nuetral
    }
    public interface ICharacter
    {
        int health { get; set; }
        Team team { get; set; }
        void Attack(ICharacter target);
        void Die(ICharacter killer);
        bool isDead { get; }
        bool canMove{get;}
    }
}