using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class Enemy : MonoBehaviour
    {
        public static float speedEnemy = 5.5f;
        public float speed;
        public string targetTag = "Player"; // ��� �������� �������
        public Transform targetPlayer;
        private void Start()
        {
            SetTargetWithTag(targetTag);
            speedEnemy = speed;


        }

        private void Update()
        {

            if (targetPlayer != null)
            {
                MoveToNearestPoint();
            }
        }

        // ��������� ������� � ��������� ����� � �������� ���� ����������
        public void SetTargetWithTag(string tag)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(tag);

            if (players.Length > 0)
            {
                targetPlayer = players[0].transform; // ����� ������ ��������� ������ � ��������� �����
            }
            else
            {
                Debug.LogWarning("No object found with tag: " + tag);
            }
        }

        private void MoveToNearestPoint()
        {
            Vector3 playerPosition = targetPlayer.position;

            // ������� ��� ����� ������ ��
            Collider[] colliders = Physics.OverlapSphere(transform.position, 100.0f); // 100.0f - ������ ������
            Vector3 nearestPoint = transform.position; // ������������, ��� ��������� ����� - ������� �������

            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player")) // ������������, ��� ����� ����� ��� "Player"
                {
                    Vector3 waypointPosition = collider.transform.position;

                    // ���������, �������� �� ������� ����� ����� � ������, ��� ���������� ��������� �����
                    if (Vector3.Distance(waypointPosition, playerPosition) < Vector3.Distance(nearestPoint, playerPosition))
                    {
                        nearestPoint = waypointPosition;
                    }
                }
            }

            // ������� �� � ��������� �����
            transform.LookAt(nearestPoint);
            transform.Translate(Vector3.forward * speedEnemy * Time.deltaTime);
        }
    }
}