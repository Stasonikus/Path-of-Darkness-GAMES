using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class Bos : MonoBehaviour
    {
        
        [SerializeField] private Image _healthBar;
        [SerializeField] private int deadMoney;
        [SerializeField] private float healthBos;
        public GameObject victory;

       
        public static float _healthBos;
        private Image bar;
        

        private void Start()
        {
            _healthBos = healthBos;
           
            bar = _healthBar; // Присваиваем _healthBar переменной bar
        }

        private void Update()
        {
            if (_healthBos <= 0)
            {
                // Проверка на наличие объекта Money и добавление денег
                if (Money.Instance != null)
                {
                    Money.Instance._money += deadMoney;
                }

                Destroy(gameObject);
                if (gameObject == null)
                {
                    victory.SetActive(true);
                }
            }
            
            {
                if (_healthBos <= 0)
                {
                    _healthBos *= 2;
                    
                    if (_healthBos <= 0)
                    {
                        if (Money.Instance != null)
                        {
                            Money.Instance._money += deadMoney;
                        }
                        Destroy(gameObject);
                    }
                    

                }

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Arrow"))
            {
                _healthBos -= Damage._arrow;
                float healthPercentag = (float)healthBos / _healthBos;
                bar.fillAmount = healthPercentag;
                
            }
            if (other.gameObject.CompareTag("Bullet"))
            {
                _healthBos -= Damage._bullet;
                float healthPercentag = (float)healthBos / _healthBos;
                bar.fillAmount = healthPercentag;
                
            }
            if (other.gameObject.CompareTag("Multi"))
            {
                _healthBos -= Damage._multi;
                float healthPercentag = (float)healthBos / _healthBos;
                bar.fillAmount = healthPercentag;
                
            }
        }

    }
}
