using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private float moveSpeed = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mendeteksi kombinasi input untuk animasi serong
        bool isWalkingUpLeft = verticalInput > 0 && horizontalInput < 0;
        bool isWalkingUpRight = verticalInput > 0 && horizontalInput > 0;
        bool isWalkingDownLeft = verticalInput < 0 && horizontalInput < 0;
        bool isWalkingDownRight = verticalInput < 0 && horizontalInput > 0;

        // Mengatur parameter animasi sesuai dengan input
        animator.SetBool("IsWalkingUp", verticalInput > 0 && !isWalkingUpLeft && !isWalkingUpRight);
        animator.SetBool("IsWalkingDown", verticalInput < 0 && !isWalkingDownLeft && !isWalkingDownRight);
        animator.SetBool("IsWalkingLeft", horizontalInput < 0 && !isWalkingUpLeft && !isWalkingDownLeft);
        animator.SetBool("IsWalkingRight", horizontalInput > 0 && !isWalkingUpRight && !isWalkingDownRight);

        // Mengaktifkan animasi kombinasi gerakan
        animator.SetBool("IsWalkingUpLeft", isWalkingUpLeft);
        animator.SetBool("IsWalkingUpRight", isWalkingUpRight);
        animator.SetBool("IsWalkingDownLeft", isWalkingDownLeft);
        animator.SetBool("IsWalkingDownRight", isWalkingDownRight);

        // Mengaktifkan animasi idle ketika tidak ada gerakan
        animator.SetBool("IsIdle", Mathf.Approximately(horizontalInput, 0) && Mathf.Approximately(verticalInput, 0));

        // Menggerakkan karakter
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        rb2d.velocity = movement;
    }
}
