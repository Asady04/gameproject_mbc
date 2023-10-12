using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastPosition;
    private Vector2 currentDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // Mendapatkan posisi saat ini
        Vector2 currentPosition = transform.position;

        // Menghitung vektor pergerakan sejak frame sebelumnya
        Vector2 movementVector = currentPosition - lastPosition;

        // Menentukan arah pergerakan berdasarkan vektor pergerakan
        float horizontalMovement = movementVector.x;
        float verticalMovement = movementVector.y;

        // Menyimpan arah pergerakan saat ini
        currentDirection = new Vector2(horizontalMovement, verticalMovement).normalized;

        // Mengaktifkan animasi berdasarkan arah pergerakan
        if (currentDirection.x > 0) // Bergerak ke kanan
        {
            ChangeAnimation("IsMovingRight");
        }
        else if (currentDirection.x < 0) // Bergerak ke kiri
        {
            ChangeAnimation("IsMovingLeft");
        }
        else if (currentDirection.y > 0) // Bergerak ke atas
        {
            ChangeAnimation("IsMovingUp");
        }
        else if (currentDirection.y < 0) // Bergerak ke bawah
        {
            ChangeAnimation("IsMovingDown");
        }

        else // NPC tidak bergerak (idle)
        {
            ChangeAnimation("IsIdle");
        }

        // Menyimpan posisi saat ini sebagai posisi terakhir
        lastPosition = currentPosition;
    }

    void ChangeAnimation(string animationParameter)
    {
        // Nonaktifkan semua parameter boolean animasi
        animator.SetBool("IsMovingRight", false);
        animator.SetBool("IsMovingLeft", false);
        animator.SetBool("IsMovingUp", false);
        animator.SetBool("IsMovingDown", false);
        animator.SetBool("IsIdle", false);

        // Aktifkan parameter boolean animasi yang sesuai
        animator.SetBool(animationParameter, true);
    }

}
