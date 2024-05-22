using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class DamageTest : MonoBehaviour
    {
        public int damageCount = 10;
        private Collider myCollider;
        public Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            myCollider = GetComponent<Collider>();

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {
                PlayerHealth.health -= damageCount;
                Enemy.speedEnemy = 3;
                myCollider.enabled = false;
                animator.SetBool("Hit", true);
                StartCoroutine(EnableColliderAfterDelay(1f));
            }
       
        }
        private void OnTriggerExit(Collider other)
        {
            animator.SetBool("Hit", false);
        }

        private IEnumerator EnableColliderAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            // ¬ключаем коллайдер
            myCollider.enabled = true;
            Enemy.speedEnemy = 5;
        }
    }
}
