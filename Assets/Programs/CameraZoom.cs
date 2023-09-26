using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 10f;

    private void Update()
    {
        float zoom = Input.GetAxis("Zoom"); // Mendeteksi input tombol "O" dan "P" pada keyboard

        if (mainCamera != null)
        {
            float currentZoom = mainCamera.orthographicSize;
            currentZoom -= zoom * zoomSpeed * Time.deltaTime;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            mainCamera.orthographicSize = currentZoom;
        }
    }
}
