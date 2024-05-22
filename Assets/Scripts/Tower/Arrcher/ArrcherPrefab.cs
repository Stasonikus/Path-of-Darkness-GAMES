using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class ArrcherPrefab : MonoBehaviour
    {
        public float speed = 5;
        public float detectionRadius = 10f; // ������ ����������� �����
        private GameObject[] enemies; // ������ ���� �������� � ����� "Enemy"
        private GameObject targetEnemy; // ��������� ����
        private Coroutine moveCoroutine;

        // Start is called before the first frame update
        void Start()
        {
            FindRandomEnemyInRadius();
        }

        // Update is called once per frame
        void Update()
        {
            if (targetEnemy == null || !IsTargetInRadius(targetEnemy))
            {
                FindRandomEnemyInRadius();
                return;
            }

            if (moveCoroutine == null)
            {
                moveCoroutine = StartCoroutine(MoveToTarget());
            }
        }

        IEnumerator MoveToTarget()
        {
            while (targetEnemy != null && IsTargetInRadius(targetEnemy))
            {
                Vector3 direction = targetEnemy.transform.position - transform.position;
                transform.Translate(direction.normalized * speed * Time.deltaTime);
                yield return null;
            }
            moveCoroutine = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

        void FindRandomEnemyInRadius()
        {
            // ������� ��� ������� � ����� "Enemy"
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            List<GameObject> enemiesInRadius = new List<GameObject>();

            foreach (GameObject enemy in allEnemies)
            {
                // ���������, ��������� �� ������ � �������
                if (IsTargetInRadius(enemy))
                {
                    enemiesInRadius.Add(enemy);
                }
            }

            if (enemiesInRadius.Count > 0)
            {
                // �������� ��������� ���� �� �������� � �������
                targetEnemy = enemiesInRadius[Random.Range(0, enemiesInRadius.Count)];
            }
            else
            {
                Debug.LogError("No Enemies found in radius!");
            }

            // ���� ���� �������� �������� ��������, ������������� �
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                moveCoroutine = null;
            }
        }

        bool IsTargetInRadius(GameObject target)
        {
            // ���������, ��������� �� ���� � �������
            return Vector3.Distance(transform.position, target.transform.position) <= detectionRadius;
        }
    }
}
