using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class SpeedBlockCollision : Simulation.Event<SpeedBlockCollision>
    {
        public PlayerController player;
        public SpeedBoxInstance block;
        

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            player.maxSpeed = 20;
            Debug.Log("Player speed:" + player.maxSpeed);
        }
    }
}