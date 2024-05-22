using System.Collections;
using UnityEngine;

namespace StarterAssets
{
    public class DamageAnimator : MonoBehaviour
    {

        public Animator animator;
        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                animator.SetBool("Hit", true);
                
            }
        }

    }
}
