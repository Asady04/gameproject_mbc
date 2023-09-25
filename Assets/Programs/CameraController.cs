using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float scrollBorderThickness = 10f;
    public Vector2 minPosition;
    public Vector2 maxPosition;
   

    private Camera mainCamera;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.mousePosition.x <= scrollBorderThickness)
        {
            moveDirection.x = -1;
        }
        else if (Input.mousePosition.x >= Screen.width - scrollBorderThickness)
        {
            moveDirection.x = 1;
        }

        if (Input.mousePosition.y <= scrollBorderThickness)
        {
            moveDirection.y = -1;
        }
        else if (Input.mousePosition.y >= Screen.height - scrollBorderThickness)
        {
            moveDirection.y = 1;
        }

        // Normalisasi vektor untuk menghindari pergerakan diagonal yang lebih cepat
        moveDirection.Normalize();

        // Pindahkan kamera berdasarkan pergerakan mouse
        Vector3 newPosition = transform.position + moveDirection * scrollSpeed * Time.deltaTime;

        // Batasan pergerakan kamera
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        transform.position = newPosition;

    }
}