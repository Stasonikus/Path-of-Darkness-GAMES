using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class kit : MonoBehaviour
      
    {
        [SerializeField] PlayerHealth Player; // ���������� ������ PlayerHealth.
        
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other) // ������� ������.
        {
            if (other.tag == "Player") // ����� �������� �������� ����.
            {
               GetComponent<PlayerHealth>().Maxhealth += 15;
                Destroy(gameObject); // �������� �������.
            }
        }
    }
}
