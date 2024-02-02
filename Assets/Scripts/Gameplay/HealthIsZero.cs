using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player health reaches 0. This usually would result in a 
    /// PlayerDeath event.
    /// </summary>
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            Debug.Log("Health is zero");
            if (health.gameObject.CompareTag("Player"))
            {
                // If it's the player's health, schedule PlayerDeath
                Debug.Log("Player death scheduled");
                Simulation.Schedule<PlayerDeath>();
            }
            else
            {
                Schedule<EnemyDeath>().enemy = health.gameObject.GetComponent<EnemyController>();
            }
        }
    }
}