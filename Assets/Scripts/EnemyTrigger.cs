using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public string enemyTag = "Enemy"; // ��� ��� ������
    public Tower tower; // ������ �� ������ �����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            tower.StartShooting();
            Debug.Log("� ����");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            tower.StopShooting();
            Debug.Log("� ����");

        }
    }
}
