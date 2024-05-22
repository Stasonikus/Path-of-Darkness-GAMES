using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
 /*   [SerializeField] private float speed = 10f; // Скорость пули
    [SerializeField] private int damage = 10; // Урон пули

    private List<GameObject> targets = new List<GameObject>(); // Список целей пули

    private void Update()
    {
        if (targets.Count > 0)
        {
            // Выбираем первую цель из списка
            GameObject target = targets[0];

            // Направляем пулю к цели
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Если нет целей, уничтожаем пулю
            Destroy(gameObject);
        }
    }

    // Метод для установки списка целей
    public void SetTargets(List<GameObject> newTargets)
    {
        targets = newTargets;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Если пуля сталкивается с врагом из списка целей, наносим ему урон и уничтожаем пулю
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
