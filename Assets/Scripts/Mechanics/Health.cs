using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 10;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            TakeDamage(currentHP);
        }

        void Awake()
        {
            currentHP = maxHP;
        }
        
        /// <summary>
        /// Decrement the HP of the entity based on the passed damage value. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void TakeDamage(int damage)
        {
            currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
            Debug.Log("Taking damage" + currentHP);
            Debug.Log("player is alive?" + IsAlive);
            if (currentHP == 0)
            {
                Debug.Log(IsAlive);
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }
    }
}
