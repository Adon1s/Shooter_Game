using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

// namespace Platformer.Mechanics
// {
//     public class PlayerBossCollision : Simulation.Event<PlayerBossCollision>
//     {
//         public BossController boss; // Reference to the boss instead of a generic enemy
//         public PlayerController player;
//         
//         PlatformerModel model = Simulation.GetModel<PlatformerModel>();
//         
//         public override void Execute()
//         {
//             // Apply damage to the player
//             var playerHealth = player.GetComponent<Health>();
//             if (playerHealth != null)
//             {
//                 playerHealth.TakeDamage(damage: 5);
//             }
//         
//             // Determine the direction to bounce the player based on their position relative to the boss
//             float direction = player.transform.position.x < boss.transform.position.x ? -1 : 1;
//         
//             // Assuming you have a method to bounce the player in a specific direction
//             // The Bounce method might need to be adjusted or implemented to support directional bounce
//             player.Bounce(direction, bounceStrength: 2); // Adjust bounceStrength as needed
//         }
//         
//         public void ApplyBounceToPlayer(PlayerController player, GameObject boss, float bounceStrength)
//         {
//             // Calculate the direction from the boss to the player
//             Vector2 directionAwayFromBoss = (player.transform.position - boss.transform.position).normalized;
//         
//             // Determine the horizontal direction for the bounce (left or right away from the boss)
//             float horizontalDirection = directionAwayFromBoss.x > 0 ? 1 : -1;
//         
//             // Create a directional vector for the bounce, applying the bounce strength
//             // Assuming you want the player to bounce upwards a bit as well
//             Vector2 bounceDirection = new Vector2(horizontalDirection * bounceStrength, bounceStrength);
//         
//             // Use the Bounce method on the player's KinematicObject component
//             KinematicObject playerKinematic = player.GetComponent<KinematicObject>();
//             if (playerKinematic != null)
//             {
//                 playerKinematic.Bounce(bounceDirection);
//             }
//         }
//     }
// }