using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace StarterAssets
{
    public class BosHealth : MonoBehaviour
    {
        [SerializeField] private float bosHealth;
        [SerializeField] private Image _healthBar;
        [SerializeField] GameObject victory;
        [SerializeField] private int deadMoney;
        private Image bar;
        public static float _bosHealth;

        private void Start()
        {
            _bosHealth = bosHealth;
            bar = _healthBar; // Присваиваем _healthBar переменной bar
        }

        private void Update()
        {
            if (_bosHealth <= 0)
            {
                // Проверка на наличие объекта Money и добавление денег
                if (Money.Instance != null)
                {
                    Money.Instance._money += deadMoney;
                }

                Destroy(gameObject); // Перенос уничтожения объекта в случае, если здоровье меньше или равно нулю
                SceneManager.LoadScene(4);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                _bosHealth -= Damage._arrow;
                UpdateHealthBar();
            }
            else if (other.gameObject.CompareTag("Bullet"))
            {
                _bosHealth -= Damage._bullet;
                UpdateHealthBar();
            }
            else if (other.gameObject.CompareTag("Multi"))
            {
                _bosHealth -= Damage._multi;
                UpdateHealthBar();
            }
        }

        private void UpdateHealthBar()
        {
            float healthPercentage = _bosHealth / bosHealth;
            bar.fillAmount = healthPercentage;
        }
    }
}
