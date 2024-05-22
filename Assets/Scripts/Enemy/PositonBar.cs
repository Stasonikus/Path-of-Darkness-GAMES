using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositonBar : MonoBehaviour
{

    private Camera _camera;
    // Start is called before the first frame update
    void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
     private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
