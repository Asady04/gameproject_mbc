using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Kecepatan gerakan NPC
    public float moveRange = 5.0f; // Jarak maksimum pergerakan NPC
    public float returnInterval = 3.0f; // Waktu interval kembali ke tempat semula
    private Vector2 startPosition;
    private Vector2[] targetPositions;
    private int currentTargetIndex = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        // Mendefinisikan arah pergerakan secara berurutan
        targetPositions = new Vector2[]
        {
            startPosition + Vector2.left * moveRange,           // Kiri
            startPosition + Vector2.right * moveRange,          // Kanan
            startPosition + Vector2.up * moveRange,             // Atas
            startPosition + Vector2.down * moveRange,           // Bawah
            startPosition + (Vector2.right + Vector2.up).normalized * moveRange,  // Serong kanan atas
            startPosition + (Vector2.right + Vector2.down).normalized * moveRange, // Serong kanan bawah
            startPosition + (Vector2.left + Vector2.up).normalized * moveRange,   // Serong kiri atas
            startPosition + (Vector2.left + Vector2.down).normalized * moveRange  // Serong kiri bawah
        };

        StartMoving();
    }

    void StartMoving()
    {
        // Mulai pergerakan NPC ke arah target yang sesuai
        Vector2 targetPosition = targetPositions[currentTargetIndex];
        rb.velocity = (targetPosition - (Vector2)transform.position).normalized * moveSpeed;

        // Ganti target berikutnya secara bergantian
        currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;

        // Setel pemanggilan InvokeRepeating untuk kembali ke tempat semula
        InvokeRepeating("ReturnToStart", returnInterval, returnInterval);
    }

    void ReturnToStart()
    {
        // Kembalikan NPC ke tempat semula
        rb.velocity = (startPosition - (Vector2)transform.position).normalized * moveSpeed;
    }
}
