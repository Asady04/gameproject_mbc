using UnityEngine;

public class ElderControl : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Aktifkan animasi yang Anda inginkan saat masuk ke mode bermain
        animator.SetTrigger("StartAnimation");
    }
}
