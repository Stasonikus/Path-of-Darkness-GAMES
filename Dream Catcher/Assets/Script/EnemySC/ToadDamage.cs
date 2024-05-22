using UnityEngine;
using System.Collections;

namespace StarterAssets
{
    public class EnemyController : MonoBehaviour
    {
        public float detectionRadius = 5f; // Радиус обнаружения
        public string playerTag = "Player"; // Тег игрока
        public GameObject enemyArrowHit;
        public Transform ArrowPosition;
        public float fireRate = 1.0f;
        private float lastShotTime;
        public Animator animator;
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            lastShotTime = -fireRate;
        }

        private void Update()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
            // Если есть коллайдеры в радиусе
            foreach (Collider collider in hitColliders)
            {
                
                if (collider.CompareTag(playerTag))
                {
                    Enemy.speedEnemy = 0;
                    Debug.Log("1");
                    animator.SetBool("Hit", true);
                    
                    
                    // Выстрел при обнаружении игрока
                    break; // Выходим из цикла, так как нашли игрока
                    

                }
                else
                {
                    Enemy.speedEnemy = 4;
                  
                }
            }
        }

        private void Shoot()
        {
            // Проверяем, прошло ли достаточно времени с момента последнего выстрела
            if (Time.time - lastShotTime > fireRate)
            {
                // Обновляем время последнего выстрела
                lastShotTime = Time.time;
                // Стрельба из точки, привязанной к объекту, в текущем направлении
                Instantiate(enemyArrowHit, ArrowPosition.position, ArrowPosition.rotation);
            }
        }
    }
}
