using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlezka : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    void Update()
    {
        RotateCharacterWithMouse();
    }

    void RotateCharacterWithMouse()
    {
        Vector3 targetPosition = GetMouseWorldPosition();

        Vector3 lookDirection = targetPosition - transform.position;
        lookDirection.y = 0;

        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
}
