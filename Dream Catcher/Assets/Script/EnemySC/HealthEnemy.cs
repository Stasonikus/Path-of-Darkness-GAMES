using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class HealthEnemy : MonoBehaviour
    {
        public static int EnemyMaxHealth = 30;
        public int EnemyHealth;
        public Image bar;
        public string targetCameraTag = "MainCamera";
        private Transform targetCamera;

        void Start()
        {
            EnemyHealth = EnemyMaxHealth;
            targetCamera = GameObject.FindGameObjectWithTag(targetCameraTag).transform;
        }

        void Update()
        {
            //Debug.Log(EnemyHealth);
            bar.fillAmount = (float)EnemyHealth / EnemyMaxHealth;
            if (targetCamera != null)
            {
                bar.transform.LookAt(targetCamera);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Arrow"))
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    EnemyHealth -= 5;

                    if (EnemyHealth <= 0)
                    {
                        Destroy(gameObject);
                    }

                    Destroy(other.gameObject);
                }
            }
        }
    }
}
