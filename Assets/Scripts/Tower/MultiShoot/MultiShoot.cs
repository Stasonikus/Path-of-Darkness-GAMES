using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class MultiShoot : MonoBehaviour
    {
        [SerializeField] private float detectionRadius = 5; // Радиус поиска.
        [SerializeField] private float fireRate = 1.0f; // Время выстрела.
        [SerializeField] private float lastShootTime;

        public static float _fireAttak;
        private bool hasPerformedCheck = false;
        public Transform[] Shootpositoin; // Позиция выстрела.
        public GameObject PrefabArrow; // Префаб стрелы.
        private GameObject target; // Цель для атаки.
        public bool detected = false;

        void Start()
        {
            lastShootTime = -_fireAttak;
            _fireAttak = fireRate;
        }

        // Update is called once per frame
        void Update()
        {
            Collider[] hitcolliders = Physics.OverlapSphere(transform.position, detectionRadius); // Делаем радиус поиска.
            

            foreach (Collider collider in hitcolliders)
            {
                if (!hasPerformedCheck)
                {
                    if (Buildgrid.shoot == true)
                    {
                        hasPerformedCheck = true;
                    }
                }
                if (hasPerformedCheck == true)
                {
                    if (collider.CompareTag("Enemy"))
                    {
                        detected = true;
                        
                        target = collider.gameObject; // Устанавливаем новую цель
                        Shoot();
                        break;
                    }
                }

                    
            }

            if (!detected)
            {
                target = null; // Сбрасываем цель, если не обнаружено врагов в зоне обнаружения
                Debug.Log("Нету цели");  // Выполняем ту часть когда моб выходит из радиуса
            }
        }

        private void OnDrawGizmos() // Делаем радиус видимым.
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

        private void Shoot()
        {
           
            
             if (Time.time - lastShootTime > _fireAttak)
             {
                lastShootTime = Time.time; // Скидываем время
                foreach(Transform shootPosition in Shootpositoin )
                Instantiate(PrefabArrow, shootPosition.position, shootPosition.rotation);// Стреляем из точки, привязанной к объекту, в текущем направлении.
             }
            
        }
    }
}
