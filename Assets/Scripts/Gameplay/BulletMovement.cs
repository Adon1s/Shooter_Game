using Platformer.Mechanics;
using UnityEngine;

namespace Gameplay
{
    public class BulletMovement : MonoBehaviour
    {
        public float speed = 20f;
        public Rigidbody2D rb;
        public int damage = 1; // Damage the bullet will deal

        public void LaunchBullet(Vector2 direction)
        {
            rb.velocity = direction * speed;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Bullet collided with: " + collision.gameObject.name);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Health enemyHealth = collision.gameObject.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    Debug.Log("Enemy Health before hit: " + enemyHealth.currentHP);
                    enemyHealth.TakeDamage(damage);
                    Debug.Log("Enemy Health after hit: " + enemyHealth.currentHP);
                }
                else
                {
                    Debug.Log("Hit object does not have Health component.");
                }

                Destroy(gameObject); // Destroy bullet after collision
            }
        }
    }
}
