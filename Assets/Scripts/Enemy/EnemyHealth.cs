using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float enemyHealth;
        [SerializeField] private Image _healthBar;
        [SerializeField] private int deadMoney;
        private Image bar;
        public static float _maxEnemyHealth;

        private void Start()
        {
            _maxEnemyHealth = enemyHealth;
            bar = _healthBar; // Присваиваем _healthBar переменной bar
        }

        private void Update()
        {
            if (enemyHealth <= 0)
            {
                // Проверка на наличие объекта Money и добавление денег
                if (Money.Instance != null)
                {
                    Money.Instance._money += deadMoney;
                }

                Destroy(gameObject); // Перенос уничтожения объекта в случае, если здоровье меньше или равно нулю
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                enemyHealth -= Damage._arrow;
                UpdateHealthBar();
            }
            else if (other.gameObject.CompareTag("Bullet"))
            {
                enemyHealth -= Damage._bullet;
                UpdateHealthBar();
            }
            else if (other.gameObject.CompareTag("Multi"))
            {
                enemyHealth -= Damage._multi;
                UpdateHealthBar();
            }
        }

        private void UpdateHealthBar()
        {
            float healthPercentage = enemyHealth / _maxEnemyHealth;
            bar.fillAmount = healthPercentage;
        }
    }
}
