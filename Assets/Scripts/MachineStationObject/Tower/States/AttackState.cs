using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
 /*   [SerializeField] private float speed = 10f; // �������� ����
    [SerializeField] private int damage = 10; // ���� ����

    private List<GameObject> targets = new List<GameObject>(); // ������ ����� ����

    private void Update()
    {
        if (targets.Count > 0)
        {
            // �������� ������ ���� �� ������
            GameObject target = targets[0];

            // ���������� ���� � ����
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // ���� ��� �����, ���������� ����
            Destroy(gameObject);
        }
    }

    // ����� ��� ��������� ������ �����
    public void SetTargets(List<GameObject> newTargets)
    {
        targets = newTargets;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���� ������������ � ������ �� ������ �����, ������� ��� ���� � ���������� ����
        if (targets.Contains(other.gameObject))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }*/
}
