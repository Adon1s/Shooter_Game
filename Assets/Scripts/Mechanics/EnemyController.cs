using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : PlayerController
    {
        public PatrolPath path;
        public AudioClip ouch;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;
        
        public GameObject bulletPrefab; // The bullet prefab to shoot
        public Transform enemyFirePoint; // The point from where the bullet will be fired

        public Bounds Bounds => _collider.bounds;
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        public void ShootAtPlayer()
        {
            // Ensure bulletPrefab and firePoint are assigned
            if (bulletPrefab == null || enemyFirePoint == null)
            {
                Debug.LogError("BulletPrefab or FirePoint not assigned in EnemyController");
                return;
            }
            Vector2 playerPosition = FindObjectOfType<PlayerController>().transform.position;
            Vector2 shootingDirection = (playerPosition - (Vector2)enemyFirePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, enemyFirePoint.position, Quaternion.identity);
            bullet.tag = "EnemyBullet";
            BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();

            if (bulletMovement != null)
            {
                bulletMovement.LaunchBullet(shootingDirection, "EnemyBullet");
            }
        }


    }
}