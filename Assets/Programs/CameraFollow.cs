using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referensi ke GameObject pemain yang akan diikuti
    public float smoothSpeed = 5f; // Kecepatan pergerakan kamera mengikuti pemain
    public float maxZoom = 10f; // Tingkat zoom maksimum
    public float zoomSpeed = 5f; // Kecepatan zoom out
    private float originalOrthoSize; // Ukuran orthografik asli kamera
    private Camera cameraComponent; // Komponen kamera
    private bool zoomingOut; // Apakah kamera sedang melakukan zoom out

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
        originalOrthoSize = cameraComponent.orthographicSize;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Mengikuti pemain
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Zoom out
            if (Input.GetKey(KeyCode.UpArrow))
            {
                zoomingOut = true;
                cameraComponent.orthographicSize += zoomSpeed * Time.deltaTime;
                cameraComponent.orthographicSize = Mathf.Clamp(cameraComponent.orthographicSize, originalOrthoSize, maxZoom);
            }
            // Kembali ke zoom awal jika tidak ada input panah atas
            else if (zoomingOut)
            {
                cameraComponent.orthographicSize = originalOrthoSize;
                zoomingOut = false;
            }
        }
    }
}
