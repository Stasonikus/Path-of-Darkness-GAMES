using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{ 
 public class DestroyArrow : MonoBehaviour
 {
    public float zrange = 10;
    public float Xrange = 10;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

   
    void Update()
    {
        
        if (transform.position.z > initialPosition.z + zrange)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > initialPosition.x + Xrange)
        {
            Destroy(gameObject);
            
        }
    }

 }
}
