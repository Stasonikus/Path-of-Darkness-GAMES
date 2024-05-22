using UnityEngine;
using System.Collections;

namespace StarterAssets
{
    public class EnemyController : MonoBehaviour
    {
        public float detectionRadius = 5f; // ������ �����������
        public string playerTag = "Player"; // ��� ������
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
            // ���� ���� ���������� � �������
            foreach (Collider collider in hitColliders)
            {
                
                if (collider.CompareTag(playerTag))
                {
                    Enemy.speedEnemy = 0;
                    Debug.Log("1");
                    animator.SetBool("Hit", true);
                    
                    
                    // ������� ��� ����������� ������
                    break; // ������� �� �����, ��� ��� ����� ������
                    

                }
                else
                {
                    Enemy.speedEnemy = 4;
                  
                }
            }
        }

        private void Shoot()
        {
            // ���������, ������ �� ���������� ������� � ������� ���������� ��������
            if (Time.time - lastShotTime > fireRate)
            {
                // ��������� ����� ���������� ��������
                lastShotTime = Time.time;
                // �������� �� �����, ����������� � �������, � ������� �����������
                Instantiate(enemyArrowHit, ArrowPosition.position, ArrowPosition.rotation);
            }
        }
    }
}
