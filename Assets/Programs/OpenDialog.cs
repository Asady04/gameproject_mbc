using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenDialog : MonoBehaviour
{
    [SerializeField] GameObject pause = null;
    [SerializeField] GameObject dialog = null;
    [SerializeField] GameObject barrier = null;
    [SerializeField] GameObject bar = null;
    SpriteRenderer npc;
    public TextMeshProUGUI conversation;
    private int page;

    public string npcName = "";

    void Start()
    {
        npc = GetComponent<SpriteRenderer>();
        npc.color = Color.grey;
        barrier.SetActive(false);
    }
    public void Open()
    {
        Debug.Log("clicked");
        page = 1;
        pause.SetActive(false);
        bar.SetActive(false);
        // string jenisBangun = gameObject.GetComponent<PlayerScript>().jenisBangun;
        dialog.SetActive(true);
        Time.timeScale = 0;
        if (npcName == "elder")
        {
            Elder();
        }
        else if (npcName == "parent")
        {
            Parent();
        }
        else if (npcName == "merchant")
        {
            Merchant();
        }
    }

    public void Close()
    {
        pause.SetActive(true);
        bar.SetActive(true);
        dialog.SetActive(false);
        Time.timeScale = 1;
    }

    void Elder()
    {
        if (page == 1)
        {
            conversation.text = "Laboris ex laborum ad commodo ullamco nulla proident consequat non adipisicing ea laboris. Nulla occaecat et incididunt incididunt enim. Sint ipsum occaecat pariatur reprehenderit velit velit. Excepteur nulla qui ipsum veniam occaecat aliquip aliquip. Enim do Lorem duis consectetur mollit aute.";
        }
        else if (page == 2)
        {
            conversation.text = "Do cupidatat dolore aliqua ipsum sunt fugiat dolore ut est. Excepteur ipsum tempor tempor dolore excepteur anim. Nulla non irure ut excepteur Lorem et pariatur. Ipsum veniam sunt voluptate magna enim Lorem cupidatat ipsum mollit cupidatat. Amet eu quis voluptate veniam excepteur ut veniam ea eiusmod veniam.";
        }
        else if (page == 3)
        {
            conversation.text = "Deserunt ipsum eiusmod consequat eu ut anim non duis quis sint qui amet dolore. In fugiat eiusmod excepteur anim dolor ullamco. Esse aliqua minim qui magna minim consectetur adipisicing anim nisi.";
        }
    }
    void Parent()
    {

    }
    void Merchant()
    {

    }

    public void Next()
    {
        if (page < 3)
        {
            page++;
        }
        if (npcName == "elder")
        {
            Elder();
        }
        else if (npcName == "parent")
        {
            Parent();
        }
        else if (npcName == "merchant")
        {
            Merchant();
        }

    }

    public void Back()
    {
        if (page > 1)
        {
            page--;
        }
        if (npcName == "elder")
        {
            Elder();
        }
        else if (npcName == "parent")
        {
            Parent();
        }
        else if (npcName == "merchant")
        {
            Merchant();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang masuk ke trigger adalah pemain.
        if (collision.CompareTag("Player"))
        {
            npc.color = Color.white;
            barrier.SetActive(true); // Munculkan tombol jika pemain mendekati objek.

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Cek apakah pemain meninggalkan trigger.
        if (other.CompareTag("Player"))
        {
            npc.color = Color.grey;
            barrier.SetActive(false); // Sembunyikan tombol jika pemain meninggalkan objek.
        }
    }


}
