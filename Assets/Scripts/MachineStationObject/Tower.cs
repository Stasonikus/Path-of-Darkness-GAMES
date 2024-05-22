using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform shootingPoint; // Точка, откуда производится выстрел
    public float fireRate = 1f; // Скорострельность в выстрелах в секунду

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
            yield return new WaitForSeconds(1f / fireRate); // Ожидание с учетом скорострельности

            // Получаем ближайшую цель
            GameObject target = GetClosestTarget();

            if (target != null)
            {
                Shoot(target);
            }
        }
    }

    GameObject GetClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Предполагается, что ваши цели имеют тег "Enemy"

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
        // Создаем снаряд
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // Направляем снаряд к цели
        Vector3 direction = (target.transform.position - shootingPoint.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * 10f; // Пример скорости снаряда, вы можете настроить под свои нужды
    }
}
