using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class ArrcherPrefab : MonoBehaviour
    {
        public float speed = 5;
        public float detectionRadius = 10f; // Радиус обнаружения целей
        private GameObject[] enemies; // Массив всех объектов с тегом "Enemy"
        private GameObject targetEnemy; // Выбранная цель
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
            // Находим все объекты с тегом "Enemy"
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            List<GameObject> enemiesInRadius = new List<GameObject>();

            foreach (GameObject enemy in allEnemies)
            {
                // Проверяем, находится ли объект в радиусе
                if (IsTargetInRadius(enemy))
                {
                    enemiesInRadius.Add(enemy);
                }
            }

            if (enemiesInRadius.Count > 0)
            {
                // Выбираем случайную цель из объектов в радиусе
                targetEnemy = enemiesInRadius[Random.Range(0, enemiesInRadius.Count)];
            }
            else
            {
                Debug.LogError("No Enemies found in radius!");
            }

            // Если есть активная корутина движения, останавливаем её
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                moveCoroutine = null;
            }
        }

        bool IsTargetInRadius(GameObject target)
        {
            // Проверяем, находится ли цель в радиусе
            return Vector3.Distance(transform.position, target.transform.position) <= detectionRadius;
        }
    }
}
