using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _enemyHealth;
        [SerializeField] private Image _healthBar;

        private Image bar;
        private int _maxEnemyHealth;

        private void Start()
        {
            _maxEnemyHealth = _enemyHealth;
            bar = _healthBar; // Присваиваем _healthBar переменной bar
        }

        private void Update()
        {
            if (_enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                _enemyHealth -= Damage._arrow;
                float healthPercentage = (float)_enemyHealth / _maxEnemyHealth;
                bar.fillAmount = healthPercentage;
            }
            if (other.gameObject.CompareTag("Bullet"))
            {
                _enemyHealth -= Damage._bullet;
                float healthPercentage = (float)_enemyHealth / _maxEnemyHealth;
                bar.fillAmount = healthPercentage;
            }
            if (other.gameObject.CompareTag("Multi"))
            {
                _enemyHealth -= Damage._multi;
                float healthPercentage = (float)_enemyHealth / _maxEnemyHealth;
                bar.fillAmount = healthPercentage;
            }
        }

    }
}
