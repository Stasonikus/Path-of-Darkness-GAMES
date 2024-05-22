using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ �������
    public Transform shootingPoint; // �����, ������ ������������ �������
    public float fireRate = 1f; // ���������������� � ��������� � �������

    public void StartShooting()
    {
        StartCoroutine(ShootRoutine());
    }

    public void StopShooting()
    {
        StopAllCoroutines();
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / fireRate); // �������� � ������ ����������������

            // �������� ��������� ����
            GameObject target = GetClosestTarget();

            if (target != null)
            {
                Shoot(target);
            }
        }
    }

    GameObject GetClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // ��������������, ��� ���� ���� ����� ��� "Enemy"

        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestTarget = enemy;
                closestDistance = distance;
            }
        }

        return closestTarget;
    }

    void Shoot(GameObject target)
    {
        // ������� ������
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // ���������� ������ � ����
        Vector3 direction = (target.transform.position - shootingPoint.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * 10f; // ������ �������� �������, �� ������ ��������� ��� ���� �����
    }
}
