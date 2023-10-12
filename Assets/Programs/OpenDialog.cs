using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenDialog : MonoBehaviour
{
    [SerializeField] GameObject pause = null;
    [SerializeField] GameObject dialog = null;
    [SerializeField] GameObject hud = null;
    [SerializeField] Button interact = null;
    
    public TextMeshProUGUI conversation;
    public TextMeshProUGUI objectiveText;
    private int page;
    private int objective;
    public string npcName = "";

    void Start()
    {
        objective = PlayerPrefs.GetInt("objective");
        interact.interactable = false;
    }

    void Update()
    {
        Debug.Log(objective);
        objective = PlayerPrefs.GetInt("objective");
        switch (objective)
        {
            case 1:
                objectiveText.text = "Temui Kepala Desa";
                break;
            case 2:
                objectiveText.text = "Temui Orang tua mu";
                break;
            case 3:
                objectiveText.text = "Cari dan temukan trader yang dimaksud";
                break;
            case 4:
                objectiveText.text = "Pergi ke New Bandung kemudian Bicara dengan pedagang";
                break;
            case 5:
                objectiveText.text = "Pergi ke gedung di ujung jalanan dan cari orang berjas";
                break;
            case 6:
                objectiveText.text = "Basmi semut di sekitar gedung";
                break;
            case 7:
                objectiveText.text = "Temui orang berjas lagi";
                break;
            case 8:
                objectiveText.text = "Basmi tikus raksasa";
                break;
            case 9:
                objectiveText.text = "Temui orang berjas lagi";
                break;
            case 10:
                objectiveText.text = "Pulang lah kerumah";
                break;
            case 11:
                objectiveText.text = "Jalan masuk ke desa mu telah di hancurkan, kamu melihat kepala desa sedang di tahan orang menggunakan rompi merah maroon.";
                break;
            case 12:
                objectiveText.text = "Bicara dengan Kepala Desa";
                break;
            case 13:
                objectiveText.text = "Selamatkan orang tua mu";
                break;
            case 14:
                objectiveText.text = "Bicara dengan orang tua mu";
                break;
            case 15:
                objectiveText.text = "The End";
                break;
            default:
                break;
        }
    }
    public void Open()
    {
        page = 1;
        pause.SetActive(false);
        hud.SetActive(false);
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
        else if (npcName == "qgiver")
        {
            Qgiver();
        }
    }

    public void Close()
    {
        pause.SetActive(true);
        hud.SetActive(true);
        dialog.SetActive(false);
        Time.timeScale = 1;
        switch (objective)
        {
            case 1:
                if (npcName == "elder")
                {
                    PlayerPrefs.SetInt("objective", 2);
                }
                break;
            case 2:
                if (npcName == "parent")
                {
                    PlayerPrefs.SetInt("objective", 3);
                }
                break;
            case 3:
                if (npcName == "merchant")
                {
                    PlayerPrefs.SetInt("objective", 4);
                }
                break;
            case 4:
                if (npcName == "merchant")
                {
                    PlayerPrefs.SetInt("objective", 5);
                }
                break;
            case 5:
                if (npcName == "qgiver")
                {
                    PlayerPrefs.SetInt("objective", 6);
                }
                break;
            case 7:
               if (npcName == "qgiver")
                {
                    PlayerPrefs.SetInt("objective", 8);
                }
                break;
            case 9:
                if (npcName == "qgiver")
                {
                    PlayerPrefs.SetInt("objective", 10);
                }
                break;
            case 12:
                if (npcName == "elder")
                {
                    PlayerPrefs.SetInt("objective", 13);
                }
                break;
            case 14:
                if (npcName == "parent")
                {
                    PlayerPrefs.SetInt("objective", 15);
                }
                break;
            default:
                break;
        }
    }

    void Elder()
    {
        if (objective == 1)
        {
            if (page == 1)
            {
                conversation.text = "Kemana saja kamu? Orang tua mu mencarimu.";
            }
            else if (page == 2)
            {
                conversation.text = "Coba temui mereka";
            }
        }
        else if (objective == 12)
        {
            if (page == 1)
            {
                conversation.text = "Mereka menghancurkan desa kita, dan mereka menculik orang tua mu selamatkan mereka, saya mendengar mereka membawa orang tua mu ke arah pelabuhan.";
            }
            else if (page == 2)
            {
                conversation.text = "Sebelum kamu pergi, ambil senapan ini, kamu lebih membutuhkannya";
            }
        }
        else
        {
            conversation.text = "halo ganteng";
        }


    }
    void Parent()
    {
        if (objective == 14)
        {
            if (page == 1)
            {
                conversation.text = "Akhirnya kau sampai disini, mereka ingin memperbudak kami";
            }
            else if (page == 2)
            {
                conversation.text = "Terima Kasih, Nak";
            }
        }
        else if (objective == 2)
        {
            if (page == 1)
            {
                conversation.text = "Hah, akhirnya kamu tiba";
            }
            else if (page == 2)
            {
                conversation.text = "Ada pedagang yang mencarimu, dia mampir kesini butuh pengawal ke kota besar, siapa tahu kamu bisa mendapatkan sesuatu di kota besar itu";
            }
            else if (page == 3)
            {
                conversation.text = "Ya sudah, temui saja dia di luar, dia menggunakan jacket warna jingga, pasti terlihat";
            }
        }
        else
        {
            conversation.text = "halo ganteng";
        }
    }
    void Merchant()
    {
        if (objective == 3)
        {
            if (page == 1)
            {
                conversation.text = "Nah, tiba juga, juga saya butuh pengawal buat ke kota besar namanya New Bandung, jangan tanya, saya tidak tahu apa artinya";
            }
            else if (page == 2)
            {
                conversation.text = "Kota nya besar dan ramai, kamu mungkin bisa mendapatkan pekerjaan disana";
            }
        }
        else if (objective == 4)
        {
            if (page == 1)
            {
                conversation.text = "Akhirnya sampai juga";
            }
            else if (page == 2)
            {
                conversation.text = "Untung saja tidak ada halangan";

            }
            else if (page == 3)
            {
                conversation.text = "Buat apa saya butuh pengawal";

            }
            else if (page == 4)
            {
                conversation.text = "Mumpung anda disini, anda mungkin ingin bertemu dengan teman saya di gedung yang dulunya perkantoran, letaknya diujung jalanan, dia menggunakan jas dan berdasi, orang aneh";

            }
        }
        else
        {
            conversation.text = "halo ganteng";
        }
    }
    void Qgiver()
    {
        if (objective == 5)
        {
            if (page == 1)
            {
                conversation.text = "Kau pasti orang yang dimaksud oleh temanku";
            }
            else if (page == 2)
            {
                conversation.text = "Saya kurang kenal dengan anda";
            }
            else if (page == 3)
            {
                conversation.text = "Tapi tidak apa-apa, saya kasih pekerjaan yang mudah saja dulu";
            }
            else if (page == 4)
            {
                conversation.text = "Coba basmi semut raksasa yang berkumpul di sekitar gedung ini, nanti temui saya lagi";
            }
        }
        else if (objective == 7)
        {
            if (page == 1)
            {
                conversation.text = "Hmmm, Lumayan bagaimana kuberikan pekerjaan lagi";
            }
            else if (page == 2)
            {
                conversation.text = "Tikus raksasa juga mulai bersarang di sekitar bangunan ini, coba kamu cari dan basmi mereka";
            }
            else if (page == 3)
            {
                conversation.text = "Sebelum kau pergi, saya memberimu pistol antik ini, dulu pernah digunakan oleh polisi";
            }
        }
        else if (objective == 9)
        {
            if (page == 1)
            {
                conversation.text = "Hebat, saya berikan SMG tua ini, SMG ini bekas pasukan khusus";
            }
        }
        else
        {
            conversation.text = "halo ganteng";
        }
    }

    public void Next()
    {
        switch (objective)
        {
            case 1:
                if (page < 2)
                {
                    page++;
                }
                break;
            case 2:
                if (page < 3)
                {
                    page++;
                }
                break;
            case 3:
                if (page < 2)
                {
                    page++;
                }
                break;
            case 4:
                if (page < 4)
                {
                    page++;
                }
                break;
            case 5:
                if (page < 4)
                {
                    page++;
                }
                break;
            case 7:
                if (page < 3)
                {
                    page++;
                }
                break;
            case 12:
                if (page < 2)
                {
                    page++;
                }
                break;
            case 14:
                if (page < 2)
                {
                    page++;
                }
                break;
            default:
                break;
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
        else if (npcName == "qgiver")
        {
            Qgiver();
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
        else if (npcName == "qgiver")
        {
            Qgiver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
      // Cek apakah yang masuk ke trigger adalah pemain.
      if (collision.CompareTag("NPC"))
      {
         interact.interactable = true;

      }
      
      if (collision.CompareTag("Enemy"))
      {
         Destroy(collision.gameObject);

      }

      if (Input.GetKeyDown(KeyCode.F))
      {
         Debug.Log("f pressed");
         Open();
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      // Cek apakah pemain meninggalkan trigger.
      if (other.CompareTag("NPC"))
      {
         interact.interactable = false;
      }
   }

}


