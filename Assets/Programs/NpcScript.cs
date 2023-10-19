using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
   [SerializeField] GameObject pressF = null;
   SpriteRenderer npc;
   public string npcName;
   public int objective;

   void Start()
   {
      npc = GetComponent<SpriteRenderer>();
      npc.color = Color.grey;
      pressF.SetActive(false);
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
      // Cek apakah yang masuk ke trigger adalah pemain.
      if (collision.CompareTag("Player"))
      {
         collision.GetComponent<OpenDialog>().npcName = npcName;
         collision.GetComponent<OpenDialog>().obj = objective;
         npc.color = Color.white;
         pressF.SetActive(true); // Munculkan tombol jika pemain mendekati objek.

      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      // Cek apakah pemain meninggalkan trigger.
      if (other.CompareTag("Player"))
      {
         npc.color = Color.grey;
         pressF.SetActive(false); // Sembunyikan tombol jika pemain meninggalkan objek.
      }
   }

}
