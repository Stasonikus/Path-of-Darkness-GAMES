using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class Arrcher : MonoBehaviour
    {
        [SerializeField] public float detectionRadius; // ������ ������.
        [SerializeField] public float fireRate = 1.0f; // ����� ��������.
        [SerializeField] private float lastShootTime;


        public Transform Shootpositoin; // ������� ��������.
        public GameObject PrefabArrow; // ������ ������.
        bool playerDetected = false;


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
                if (collider.CompareTag("Enemy"))
                {
                    playerDetected = true;
                    Debug.Log("�������");
                    Shoot();
                    break;
                }
            }
            if (!playerDetected)
            {
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
                lastShootTime = Time.time; // ������� �����
                Instantiate(PrefabArrow, Shootpositoin.position, Shootpositoin.rotation);// �������� �� �����, ����������� � �������, � ������� �����������.
            }
        }
    }
}