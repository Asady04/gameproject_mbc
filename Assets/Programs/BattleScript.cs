using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class BattleScript : MonoBehaviour
{
    [SerializeField] GameObject smg = null;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject hud = null;
    [SerializeField] GameObject pause = null;
    [SerializeField] GameObject playersmg = null;
    [SerializeField] GameObject spear = null;
    [SerializeField] GameObject playerspear = null;
    [SerializeField] GameObject pistol = null;
    [SerializeField] GameObject playerpistol = null;
    [SerializeField] GameObject rifle = null;
    [SerializeField] GameObject playerrifle = null;
    [SerializeField] GameObject bandit = null;
    [SerializeField] GameObject ant = null;
    [SerializeField] GameObject rat = null;
    [SerializeField] GameObject barrier = null;
    [SerializeField] GameObject gameOver = null;
    [SerializeField] GameObject battle = null;
    [SerializeField] Button attack = null;
    [SerializeField] Button heal = null;
    [SerializeField] Button flee = null;
    public TextMeshProUGUI notification;
    public TextMeshProUGUI myHealthText;
    public TextMeshProUGUI enemyHealthText;
    AudioManager audioManager;
    private int weapon;
    private int myHealth = 100;
    private int enemyHealth = 100;
    private int myDmg;
    private int enemyDmg;
    private int objective;
    private bool myturn;
    public bool win = false;
    public string enemyName = "";

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Mulai()
    {
        player.SetActive(false);
        hud.SetActive(false);
        pause.SetActive(false);
        weapon = 1;
        myturn = true;
        myHealth = 100;
        enemyHealth = 100;
        if (enemyName == "bandit")
        {
            bandit.SetActive(true);
        }
        else if (enemyName == "ant")
        {
            ant.SetActive(true);
        }
        else if (enemyName == "rat")
        {
            rat.SetActive(true);
        }
    }

    void Update()
    {
        objective = PlayerPrefs.GetInt("objective");
        if (myHealth <= 0)
        {
            gameOver.SetActive(true);
            battle.SetActive(false);
            player.SetActive(false);
        }
        else if (enemyHealth <= 0)
        {
            bandit.SetActive(false);
            ant.SetActive(false);
            rat.SetActive(false);
            player.SetActive(true);
            win = true;
            hud.SetActive(true);
            battle.SetActive(false);
            pause.SetActive(true);

            if (objective == 6 && enemyName == "ant")
            {
                PlayerPrefs.SetInt("objective", 7);
            }
            else if (objective == 8 && enemyName == "rat")
            {
                PlayerPrefs.SetInt("objective", 9);
            }
            else if (objective == 11 && enemyName == "bandit")
            {
                PlayerPrefs.SetInt("objective", 12);
            }
            else if (objective == 13 && enemyName == "bandit")
            {
                PlayerPrefs.SetInt("objective", 14);
            }

        }
        myHealthText.text = "Health: " + myHealth;
        enemyHealthText.text = "Health: " + enemyHealth;
        switch (weapon)
        {
            case 1:
                spear.SetActive(true);
                playerspear.SetActive(true);
                pistol.SetActive(false);
                playerpistol.SetActive(false);
                smg.SetActive(false);
                playersmg.SetActive(false);
                rifle.SetActive(false);
                playerrifle.SetActive(false);
                myDmg = Random.Range(20, 25);
                break;
            case 2:
                spear.SetActive(false);
                playerspear.SetActive(false);
                pistol.SetActive(true);
                playerpistol.SetActive(true);
                smg.SetActive(false);
                playersmg.SetActive(false);
                rifle.SetActive(false);
                playerrifle.SetActive(false);
                myDmg = Random.Range(25, 35);
                break;
            case 3:
                spear.SetActive(false);
                playerspear.SetActive(false);
                pistol.SetActive(false);
                playerpistol.SetActive(false);
                smg.SetActive(true);
                playersmg.SetActive(true);
                rifle.SetActive(false);
                playerrifle.SetActive(false);
                myDmg = Random.Range(40, 60);
                break;
            case 4:
                spear.SetActive(false);
                playerspear.SetActive(false);
                pistol.SetActive(false);
                playerpistol.SetActive(false);
                smg.SetActive(false);
                playersmg.SetActive(false);
                rifle.SetActive(true);
                playerrifle.SetActive(true);
                myDmg = Random.Range(80, 95);
                break;
            default:
                break;
        }

        if (!myturn)
        {
            if (enemyName == "bandit")
            {
                Invoke("Bandit", 1);
            }
            else if (enemyName == "ant")
            {
                Invoke("Ant", 1);
            }
            else if (enemyName == "rat")
            {
                Invoke("Rat", 1); 
            }
            
            myturn = !myturn;
        }


    }

    private void StopAtk()
    {
        attack.interactable = false;
        heal.interactable = false;
        flee.interactable = false;
        playerpistol.GetComponent<Animator>().SetBool("atk", false);
        playersmg.GetComponent<Animator>().SetBool("atk", false);
        playerrifle.GetComponent<Animator>().SetBool("atk", false);
        playerspear.GetComponent<Animator>().SetBool("atk", false);
    }
    public void Attack()
    {
        switch (weapon)
        {
            case 1:
                playerspear.GetComponent<Animator>().SetBool("atk", true);
                break;
            case 2:
                playerpistol.GetComponent<Animator>().SetBool("atk", true);
                audioManager.PlaySFX(audioManager.pistol);
                break;
            case 3:
                playersmg.GetComponent<Animator>().SetBool("atk", true);
                audioManager.PlaySFX(audioManager.smg);
                break;
            case 4:
                playerrifle.GetComponent<Animator>().SetBool("atk", true);
                audioManager.PlaySFX(audioManager.rifle);
                break;
            default:
                break;
        }
        Invoke("StopAtk", 1);
        notification.text = enemyName + " terkena " + myDmg + " DMG.";
        enemyHealth = enemyHealth - myDmg;
        myturn = !myturn;
        barrier.SetActive(true);
        
    }
    public void Heal()
    {
        int potion = Random.Range(10, 20);
        myHealth = myHealth + potion;
        if (myHealth > 100)
        {
            myHealth = 100;
        }
        myturn = !myturn;
        barrier.SetActive(true);
        attack.interactable = false;
        heal.interactable = false;
        flee.interactable = false;
        audioManager.PlaySFX(audioManager.heal);
    }
    public void Flee()
    {
        battle.SetActive(false);
        int a = PlayerPrefs.GetInt("map");
        SceneManager.LoadScene(a + 2);
        player.SetActive(true);
    }

    public void Retry()
    {
        enemyHealth = 100;
        myHealth = 100;
        gameOver.SetActive(false);
        battle.SetActive(true);
    }

   void StopEnemy(){
        bandit.GetComponent<Animator>().SetBool("atk", false);
        rat.GetComponent<Animator>().SetBool("atk", false);
        ant.GetComponent<Animator>().SetBool("atk", false);
    }
    void Bandit()
    {
        bandit.GetComponent<Animator>().SetBool("atk", true);
        enemyDmg = Random.Range(30, 45);
        myHealth = myHealth - enemyDmg;
        notification.text = "Player terkena " + enemyDmg + " DMG.";
        attack.interactable = true;
        heal.interactable = true;
        flee.interactable = true;
        barrier.SetActive(false);
        Invoke("StopEnemy", 1);
    }
    void Rat()
    {
        rat.GetComponent<Animator>().SetBool("atk", true);
        enemyDmg = Random.Range(25, 30);
        myHealth = myHealth - enemyDmg;
        notification.text = "Player terkena " + enemyDmg + " DMG.";
        attack.interactable = true;
        heal.interactable = true;
        flee.interactable = true;
        barrier.SetActive(false);
        Invoke("StopEnemy", 1);

    }
    void Ant()
    {
        ant.GetComponent<Animator>().SetBool("atk", true);
        enemyDmg = Random.Range(19, 24);
        myHealth = myHealth - enemyDmg;
        notification.text = "Player terkena " + enemyDmg + " DMG.";
        attack.interactable = true;
        heal.interactable = true;
        flee.interactable = true;
        barrier.SetActive(false);
        Invoke("StopEnemy", 1);
    }

    public void Next()
    {
        if (objective >= 13)
        {
            if (weapon < 4)
            {
                weapon++;
            }
        }
        else if (objective >= 10)
        {
            if (weapon < 3)
            {
                weapon++;
            }
        }

        else if (objective >= 8)
        {
            if (weapon < 2)
            {
                weapon++;
            }
        }



    }

    public void Prev()
    {
        if (weapon > 1)
        {
            weapon--;
        }
    }

}
