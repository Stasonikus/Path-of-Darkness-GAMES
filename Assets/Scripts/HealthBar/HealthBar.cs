using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
   private void AliginCamera()
    {
        if(mainCamera != null)
        {
            var camXfrom = mainCamera.transform;
            var forward = transform.position - camXfrom.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXfrom.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}
