using UnityEngine;

namespace Platformer.Mechanics
{
    public class BossAI : MonoBehaviour
    {
        public BossController bossController;
        public float shootingInterval = 2f; // Time between shots

        private float timeSinceLastShot = 0f;

        void Update()
        {
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= shootingInterval)
            {
                bossController.ShootAtPlayer();
                timeSinceLastShot = 0f;
            }
        }
    }
}