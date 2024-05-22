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

        public Transform[] Shootpositoin; // ������� ��������.
        public GameObject PrefabArrow; // ������ ������.
        private GameObject target; // ���� ��� �����.
        public bool detected = false;

        void Start()
        {
            lastShootTime = -fireRate;
        }

        // Update is called once per frame
        void Update()
        {
            Collider[] hitcolliders = Physics.OverlapSphere(transform.position, detectionRadius); // ������ ������ ������.
            

            foreach (Collider collider in hitcolliders)
            {
                if (collider.CompareTag("Enemy") )
                {
                    detected = true;
                    Debug.Log("�������");
                    target =  collider.gameObject; // ������������� ����� ����
                    Shoot();
                    break;
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
           
            
             if (Time.time - lastShootTime > fireRate)
             {
                lastShootTime = Time.time; // ��������� �����
                foreach(Transform shootPosition in Shootpositoin )
                Instantiate(PrefabArrow, shootPosition.position, shootPosition.rotation);// �������� �� �����, ����������� � �������, � ������� �����������.
             }
            
        }
    }
}
