using UnityEngine;

namespace Platformer.Mechanics
{
    public class EnemyAI : MonoBehaviour
    {
        public EnemyController enemyController;
        public float shootingInterval = 2f; // Time between shots

        private float timeSinceLastShot = 0f;

        void Update()
        {
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= shootingInterval)
            {
                enemyController.ShootAtPlayer();
                timeSinceLastShot = 0f;
            }
        }
    }
}