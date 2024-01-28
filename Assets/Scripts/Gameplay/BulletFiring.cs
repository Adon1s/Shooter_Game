using UnityEngine;

namespace Gameplay
{
    public class BulletFiring : MonoBehaviour
    {
        public Transform firePoint; // The point from where the bullet will be fired
        public GameObject bulletPrefab; // The bullet prefab to shoot
        private SpriteRenderer spriteRenderer;

        public float bulletForce = 20f; // The force to apply to the bullet

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse button pressed - attempting to shoot.");
                Shoot();
            }
        }
        
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer not found on the GameObject");
            }
        }


        void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.tag = "PlayerBullet";
            BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();

            if (bulletMovement != null)
            {
                bool isFacingLeft = spriteRenderer.flipX;
                bulletMovement.LaunchBullet(isFacingLeft ? Vector2.left : Vector2.right, "PlayerBullet");
            }
        }

    }
}

