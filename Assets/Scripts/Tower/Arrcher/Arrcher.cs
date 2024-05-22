using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class GridArrcher : MonoBehaviour
    {
        [SerializeField] private float detectionRadius = 5; // Радиус поиска.
        [SerializeField] private float fireRate = 1.0f; // Время выстрела.
        [SerializeField] private float lastShootTime;
        [SerializeField] private GameObject Prefab;

        private bool hasPerformedCheck = false;

        public Transform Shootpositoin; // Позицыя выстрела.
        public GameObject PrefabArrow; // Префаб стрелы.
        bool playerDetected = false;


        void Start()
        {
            lastShootTime = -fireRate;
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
                        playerDetected = true;
                        
                        Shoot();
                        break;
                    }
                }
                
            }
            if (!playerDetected)
            {
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
            if (Time.time - lastShootTime > fireRate)
            {
                lastShootTime = Time.time; // Скидаем время
                Instantiate(PrefabArrow, Shootpositoin.position, Shootpositoin.rotation);// Стреляба из точки, привязанной к объекту, в текущем направлении.
            }
        }
    }
}