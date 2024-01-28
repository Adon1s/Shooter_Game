using Platformer.Mechanics;
using UnityEngine;

namespace Gameplay
{
    public class BulletMovement : MonoBehaviour
    {
        public float speed = 20f;
        public Rigidbody2D rb;
        public int damage = 1; // Damage the bullet will deal

        public void LaunchBullet(Vector2 direction, string bulletTag)
        {
            rb.velocity = direction * speed;
            gameObject.tag = bulletTag; // Set the tag dynamically

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("EnemyBullet"))
            {
                // Handle interaction with the player, like dealing damage
                // TODO: Add logic to damage the player

                Destroy(gameObject); // Destroy the enemy bullet
            }
        }


        void OnCollisionEnter2D(Collision2D collision)
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            
            // Ignore collision if a player bullet hits the player
            if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("PlayerBullet"))
            {
                return; // Exit the function to prevent further processing
            }

            // Ignore collision if an enemy bullet hits another enemy
            if (collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("EnemyBullet"))
            {
                return; // Exit the function to prevent further processing
            }

            // Handle collision with the player and enemy bullets
            if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("EnemyBullet"))
            {
                // Perform actions like damaging the player, triggering effects, etc.
                // ...

                Destroy(gameObject); // Destroy the bullet
                //TODO playerHealth.TakeDamage(damage);

                return; // Exit the function to prevent further processing
            }

            // Handle collision with the enemy (bullet fired by player)
            if (collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("PlayerBullet"))
            {
                // Perform actions like damaging the enemy, triggering effects, etc.
                // ...
                enemyHealth.TakeDamage(damage);
                Destroy(gameObject); // Destroy the bullet
                Debug.Log("Enemy health = " + enemyHealth);

                return; // Exit the function to prevent further processing
            }

            // Handle collision with the environment or other objects
            if (collision.gameObject.CompareTag("Level"))
            {
                // Trigger effects like bullet impact, etc.
                // ...

                Destroy(gameObject); // Destroy the bullet
                return; // Exit the function to prevent further processing
            }

            // Optionally, handle other specific collisions here
            // ...

            // Destroy the bullet for any other type of collision not covered above
            Destroy(gameObject);
        }

    }
}
