using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class kit : MonoBehaviour
      
    {
        [SerializeField] PlayerHealth Player; // Используем скрипт PlayerHealth.
        
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other) // Вызываю тригер.
        {
            if (other.tag == "Player") // Делаю проверку назвиния тега.
            {
               GetComponent<PlayerHealth>().Maxhealth += 15;
                Destroy(gameObject); // Удаления Обьекта.
            }
        }
    }
}
