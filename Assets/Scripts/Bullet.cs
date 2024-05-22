using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float fireRate = 1f; // ���������������� � ��������� � �������
    [SerializeField] private GameObject projectilePrefab; // ������ �������
    [SerializeField] private Transform shootingPoint; // �����, ������ ������������ �������

    private GameObject target; // ���� ����� (����)

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / fireRate); // �������� � ������ ����������������

            if (target != null)
            {
                Shoot(target);
            }
        }
    }

    void Shoot(GameObject target)
    {
        // ������� ������
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // ���������� ������ � ����
        Vector3 direction = (target.transform.position - shootingPoint.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * 10f; // ������ �������� �������, �� ������ ��������� ��� ���� �����
    }

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
