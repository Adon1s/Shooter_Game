using UnityEngine;

namespace Gameplay
{
    public class BulletFiring : MonoBehaviour
    {
        public Transform firePoint; // The point from where the bullet will be fired
        public GameObject bulletPrefab; // The bullet prefab to shoot

        public float bulletForce = 20f; // The force to apply to the bullet

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse button pressed - attempting to shoot.");
                Shoot();
            }
        }

        void Shoot()
        {
            Debug.Log("Shoot method called.");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Create a bullet instance
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Assuming the bullet has a Rigidbody2D component

            if (rb != null)
            {
                rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); // Add force to the bullet
                Debug.Log("Bullet instantiated and force applied.");
            }
            else
            {
                Debug.Log("Rigidbody2D not found on the bullet prefab.");
            }
        }
    }
}
