using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class Enemy : MonoBehaviour
    {
        public static float speedEnemy = 5.5f;
        public float speed;
        public string targetTag = "Player"; // Тег целевого объекта
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

        // Установка объекта с указанным тегом в качестве цели следования
        public void SetTargetWithTag(string tag)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(tag);

            if (players.Length > 0)
            {
                targetPlayer = players[0].transform; // Берем первый найденный объект с указанным тегом
            }
            else
            {
                Debug.LogWarning("No object found with tag: " + tag);
            }
        }

        private void MoveToNearestPoint()
        {
            Vector3 playerPosition = targetPlayer.position;

            // Находим все точки вокруг ИИ
            Collider[] colliders = Physics.OverlapSphere(transform.position, 100.0f); // 100.0f - радиус поиска
            Vector3 nearestPoint = transform.position; // Предполагаем, что ближайшая точка - текущая позиция

            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player")) // Предполагаем, что точки имеют тег "Player"
                {
                    Vector3 waypointPosition = collider.transform.position;

                    // Проверяем, является ли текущая точка ближе к игроку, чем предыдущая ближайшая точка
                    if (Vector3.Distance(waypointPosition, playerPosition) < Vector3.Distance(nearestPoint, playerPosition))
                    {
                        nearestPoint = waypointPosition;
                    }
                }
            }

            // Двигаем ИИ к ближайшей точке
            transform.LookAt(nearestPoint);
            transform.Translate(Vector3.forward * speedEnemy * Time.deltaTime);
        }
    }
}