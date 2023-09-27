using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject battleScene;
    public string name;
    public Transform player;
    public float hitPlayer = 0f; // Jarak minimal di mana musuh akan mengikuti pemain
    public float followDistance = 5f; // Jarak minimal di mana musuh akan mengikuti pemain
    public float returnDistance = 10f; // Jarak maksimal dari posisi semula sebelum musuh kembali
    public float moveSpeed = 3f; // Kecepatan pergerakan musuh

    private Vector3 originalPosition; // Posisi semula musuh

    private void Start()
    {
        originalPosition = transform.position; // Simpan posisi semula
    }

    private void Update()
    {
        // Hitung jarak antara musuh dan pemain
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Jika pemain berada dalam jarak followDistance, musuh akan mengikuti pemain
        if (distanceToPlayer <= followDistance)
        {
            // Arahkan musuh ke arah pemain
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }

        // Jika pemain berada di luar jarak returnDistance dari posisi semula, musuh akan kembali
        else if (distanceToPlayer >= returnDistance)
        {
            // Kembali ke posisi semula
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang masuk ke trigger adalah pemain.
        if (collision.CompareTag("Player"))
        {
            battleScene.GetComponent<BattleScript>().enemyName = name;
            battleScene.SetActive(true);

        }
    }
}
