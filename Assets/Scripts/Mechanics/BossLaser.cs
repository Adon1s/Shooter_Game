using UnityEngine;

namespace Platformer.Mechanics
{
    public class LaserScript : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
        private Collider2D collider; // Reference to the Collider component

        void Awake()
        {
            // Get the SpriteRenderer and Collider components from the laser GameObject
            spriteRenderer = GetComponent<SpriteRenderer>();
            collider = GetComponent<Collider2D>();
        }

        void Start()
        {
            // Make the laser disappear after 2 seconds
            Invoke(nameof(Disappear), 2f);
        }

        void Disappear()
        {
            // Disable the sprite renderer and collider to make the laser "disappear"
            spriteRenderer.enabled = false;
            collider.enabled = false;
        
            // Optionally, destroy the laser GameObject after a short delay to clean up
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Detected collision with the player
                Debug.Log("Laser has hit the player!");

                // Here you can implement the logic for what happens when the laser hits the player
                // For example, you can retrieve the Health component from the player GameObject and apply damage  
                PlayerController player = other.GetComponent<PlayerController>();
                player.health.TakeDamage(5); // Apply damage to the player
            }
        }
    }
}