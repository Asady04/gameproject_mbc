using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan karakter

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Mengambil input dari pemain
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Mendeteksi input tombol "W", "A", "S", dan "D"
        if (Input.GetKey("w"))
        {
            verticalInput = 1f;
        }
        if (Input.GetKey("a"))
        {
            horizontalInput = -1f;
        }
        if (Input.GetKey("s"))
        {
            verticalInput = -1f;
        }
        if (Input.GetKey("d"))
        {
            horizontalInput = 1f;
        }

        // Menghitung vektor pergerakan
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;

        // Menggerakkan karakter
        rb.velocity = movement;
    }
}
