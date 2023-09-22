using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDialog : MonoBehaviour
{
    [SerializeField] GameObject pause = null;
    [SerializeField] GameObject dialog = null;
    [SerializeField] GameObject barrier = null;
    [SerializeField] GameObject bar = null;
    [SerializeField] Button npc = null;
    public void Open()
    {
        pause.SetActive(false);
        bar.SetActive(false);
        // string jenisBangun = gameObject.GetComponent<PlayerScript>().jenisBangun;
        dialog.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        pause.SetActive(true);
        bar.SetActive(true);
        dialog.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang masuk ke trigger adalah pemain.
        if (collision.CompareTag("Player"))
        {
            // pemainMendekati = true;
            npc.interactable = true;
            barrier.SetActive(true); // Munculkan tombol jika pemain mendekati objek.
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Cek apakah pemain meninggalkan trigger.
        if (other.CompareTag("Player"))
        {
            // pemainMendekati = false;
            npc.interactable = false;
            barrier.SetActive(false); // Sembunyikan tombol jika pemain meninggalkan objek.
        }
    }


}
