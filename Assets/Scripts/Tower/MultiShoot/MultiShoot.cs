using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class MultiShoot : MonoBehaviour
    {
        [SerializeField] private float detectionRadius = 5; // ������ ������.
        [SerializeField] private float fireRate = 1.0f; // ����� ��������.
        [SerializeField] private float lastShootTime;

        public static float _fireAttak;
        private bool hasPerformedCheck = false;
        public Transform[] Shootpositoin; // ������� ��������.
        public GameObject PrefabArrow; // ������ ������.
        private GameObject target; // ���� ��� �����.
        public bool detected = false;

        void Start()
        {
            lastShootTime = -_fireAttak;
            _fireAttak = fireRate;
        }

        // Update is called once per frame
        void Update()
        {
            Collider[] hitcolliders = Physics.OverlapSphere(transform.position, detectionRadius); // ������ ������ ������.
            

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
                        
                        target = collider.gameObject; // ������������� ����� ����
                        Shoot();
                        break;
                    }
                }

                    
            }

            if (!detected)
            {
                target = null; // ���������� ����, ���� �� ���������� ������ � ���� �����������
                Debug.Log("���� ����");  // ��������� �� ����� ����� ��� ������� �� �������
            }
        }

        private void OnDrawGizmos() // ������ ������ �������.
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

        private void Shoot()
        {
           
            
             if (Time.time - lastShootTime > _fireAttak)
             {
                lastShootTime = Time.time; // ��������� �����
                foreach(Transform shootPosition in Shootpositoin )
                Instantiate(PrefabArrow, shootPosition.position, shootPosition.rotation);// �������� �� �����, ����������� � �������, � ������� �����������.
             }
            
        }
    }
}
