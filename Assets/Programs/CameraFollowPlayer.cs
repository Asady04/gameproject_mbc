using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target; // Referensi ke transform karakter player
    public float smoothSpeed = 5f; // Kecepatan pergerakan kamera

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
