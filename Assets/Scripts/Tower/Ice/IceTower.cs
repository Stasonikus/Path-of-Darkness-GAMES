using UnityEngine;
using System.Collections.Generic;

namespace StarterAssets
{
     public class SpeedModifier : MonoBehaviour
     {
        public float modifiedSpeed = 0.5f; // Измененная скорость, когда объект входит в коллайдер
        private Dictionary<GameObject, float> originalSpeeds = new Dictionary<GameObject, float>(); // Словарь для хранения исходных скоростей объектов
        private bool hasPerformedCheck = false;

        private void OnTriggerEnter(Collider other)
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
                if (other.CompareTag("Enemy"))
                {
                    GameObject enemyObject = other.gameObject;
                    // Если скорость еще не была изменена, сохраняем исходную скорость и модифицируем скорость объекта
                    if (!originalSpeeds.ContainsKey(enemyObject))
                    {
                        EnemyRouteLogic enemyRouteLogic = enemyObject.GetComponent<EnemyRouteLogic>();
                        if (enemyRouteLogic != null)
                        {
                            originalSpeeds[enemyObject] = enemyRouteLogic._speed;
                            enemyRouteLogic._speed *= modifiedSpeed;
                        }
                    }
                }
            }
                
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                GameObject enemyObject = other.gameObject;
                // Если скорость была изменена и объект больше не находится в коллайдере, возвращаем исходную скорость
                if (originalSpeeds.ContainsKey(enemyObject))
                {
                    RestoreSpeed(enemyObject);
                    originalSpeeds.Remove(enemyObject);
                }
            }
        }

        private void RestoreSpeed(GameObject enemyObject)
        {
            EnemyRouteLogic enemyRouteLogic = enemyObject.GetComponent<EnemyRouteLogic>();
            if (enemyRouteLogic != null)
            {
                enemyRouteLogic._speed = originalSpeeds[enemyObject];
            }
        }
     }
    
}
