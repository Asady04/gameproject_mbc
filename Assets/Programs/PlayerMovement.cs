using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan pergerakan karakter

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput == 0 || horizontalInput == 0)
        {

        }
        else
        {
            Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;

            rb2d.velocity = movement;
        }

    }
}
