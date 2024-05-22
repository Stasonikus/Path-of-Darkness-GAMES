using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float fireRate = 1f; // Скорострельность в выстрелах в секунду
    [SerializeField] private GameObject projectilePrefab; // Префаб снаряда
    [SerializeField] private Transform shootingPoint; // Точка, откуда производится выстрел

    private GameObject target; // Цель атаки (враг)

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / fireRate); // Ожидание с учетом скорострельности

            if (target != null)
            {
                Shoot(target);
            }
        }
    }

    void Shoot(GameObject target)
    {
        // Создаем снаряд
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // Направляем снаряд к цели
        Vector3 direction = (target.transform.position - shootingPoint.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * 10f; // Пример скорости снаряда, вы можете настроить под свои нужды
    }

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
