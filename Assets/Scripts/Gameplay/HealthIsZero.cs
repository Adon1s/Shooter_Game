using Platformer.Core;
using Platformer.Mechanics;
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
            if (health.gameObject.CompareTag("Player"))
            {
                // If it's the player's health, schedule PlayerDeath
                Schedule<PlayerDeath>();
            }
            else
            {
                // Handle enemy death, or do nothing if it's not needed
            }
        }
    }
}