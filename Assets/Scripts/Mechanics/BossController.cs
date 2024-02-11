using System.Collections;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class BossController : PlayerController
    {
        // public PatrolPath path;
        // public AudioClip ouch;

        // internal PatrolPath.Mover mover;
        // internal AnimationController control;
         internal Collider2D _collider;
        // internal AudioSource _audio;
        public SpriteRenderer spriteRenderer;
        
        public Transform enemyFirePoint; // The point from where the bullet will be fired
        public GameObject laserPrefab; // The laser prefab to instantiate
        
        private Health playerHealth;
        private Coroutine damageCoroutine;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            //control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private IEnumerator DealDamageOverTime(PlayerController player, float damage, float interval)
        {
            while (true) // Keep dealing damage until the coroutine is stopped
            {
                if (player != null)
                {
                    playerHealth.TakeDamage(5);
                }
                yield return new WaitForSeconds(interval);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null && damageCoroutine == null) // Start damage coroutine only if not already started
            {
                damageCoroutine = StartCoroutine(DealDamageOverTime(player, 5f, 2f));
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null && damageCoroutine != null) // Stop the coroutine when the player exits the collision
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }

        void Update()
        {
            
        }
        // ... other parts of the EnemyController ...

        public void ShootAtPlayer()
        {
            // Ensure laserPrefab and enemyFirePoint are assigned
            if (laserPrefab == null || enemyFirePoint == null)
            {
                Debug.LogError("LaserPrefab or FirePoint not assigned in EnemyController");
                return;
            }

            // Find the player's position
            Vector2 playerPosition = FindObjectOfType<PlayerController>().transform.position;

            // Instantiate the laser at the fire point
            GameObject laser = Instantiate(laserPrefab, enemyFirePoint.position, Quaternion.identity);
            
            // Optional: Set the laser's parent to keep the hierarchy organized
            laser.transform.SetParent(this.transform);

            // Calculate the angle towards the player
            Vector2 direction = playerPosition - (Vector2)enemyFirePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the laser's rotation to point towards the player
            laser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // You could add a tag or set the laser's layer if needed for collision detection
            // e.g., laser.tag = "EnemyLaser";
        }


    }
}