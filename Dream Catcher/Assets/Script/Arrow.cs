using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class Arrow : MonoBehaviour
    {
        public float speed = 10f;
        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            StartCoroutine(MyCorutine());
        }


        IEnumerator MyCorutine()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
        
    }
}
