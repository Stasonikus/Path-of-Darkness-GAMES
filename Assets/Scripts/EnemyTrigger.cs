using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Тег для врагов
    public Tower tower; // Ссылка на скрипт башни

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            tower.StartShooting();
            Debug.Log("В зоне");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            tower.StopShooting();
            Debug.Log("С зоны");

        }
    }
}
