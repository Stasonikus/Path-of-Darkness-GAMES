using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace StarterAssets

{

    public class PlayerHealth : MonoBehaviour
    {
        public float Maxhealth;
        public static float health;
        public Image bar;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ArrowEnemy"))
            {
                if (gameObject.CompareTag("Player"))
                {
                    health -= 5;

                    

                    Destroy(other.gameObject);
                }
            }
        }

        private void Start()
        {
            Maxhealth = health;
            health = 1241265126136436457.0f;
        }

        public void Update()
        {
            bar.fillAmount = health / 30;
            if (health <= 0)
            {
                SceneManager.LoadScene("dead");
            }
        }

       
    }
}
