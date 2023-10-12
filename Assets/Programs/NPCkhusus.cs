using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Kecepatan pergerakan game objek
    public float moveDistanceRight = 5.0f; // Jarak game objek bergerak ke kanan
    public float moveDistanceLeft = 5.0f; // Jarak game objek bergerak ke kiri
    public Animator animator; // Komponen Animator

    private Vector3 initialPosition;
    private bool isMovingRight = true; // Menyimpan arah pergerakan saat ini

    void Start()
    {
        initialPosition = transform.position;

        // Pastikan Animator telah ditambahkan ke GameObject ini.
        if (animator == null)
        {
            Debug.LogError("Animator component is not assigned to the GameObject.");
        }
    }

    void Update()
    {
        if (isMovingRight)
        {
            // Game objek bergerak ke kanan
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            animator.SetBool("IsMovingRight", true); // Aktifkan animasi bergerak ke kanan
            animator.SetBool("IsMovingLeft", false);
            // Jika mencapai batasan pergerakan ke kanan
            if (transform.position.x >= initialPosition.x + moveDistanceRight)
            {
                isMovingRight = false; // Ganti arah ke kiri
                animator.SetBool("IsMovingRight", false); // Nonaktifkan animasi bergerak ke kanan
            }
        }
        else
        {
            // Game objek bergerak ke kiri
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            animator.SetBool("IsMovingRight", false); // Aktifkan animasi bergerak ke kiri
            animator.SetBool("IsMovingLeft", true);
            // Jika mencapai batasan pergerakan ke kiri
            if (transform.position.x <= initialPosition.x - moveDistanceLeft)
            {
                isMovingRight = true; // Ganti arah ke kanan
                animator.SetBool("IsMovingRight", true); // Aktifkan animasi bergerak ke kanan
            }
        }
    }
}
