using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class BattleScript : MonoBehaviour
{
    [SerializeField] GameObject smg = null;
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
    private int weapon;
    private int myHealth;
    private int enemyHealth;
    private int myDmg;
    private int enemyDmg;
    private int objective;
    private bool myturn;
    public bool win = false;
    public string enemyName = "";

    void Start()
    {
        hud.SetActive(false);
        win = false;
        pause.SetActive(false);
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
        weapon = 1;
        myHealth = 100;
        enemyHealth = 100;
        myturn = true;
    }

    void Update()
    {
        objective = PlayerPrefs.GetInt("objective");
        if (myHealth <= 0)
        {
            gameOver.SetActive(true);
            battle.SetActive(false);
        }
        else if (enemyHealth <= 0)
        {
            win = true;
            hud.SetActive(true);
            battle.SetActive(false);

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
                Invoke("Bandit", 2);
            }
            else if (enemyName == "ant")
            {
                Invoke("Ant", 2);
            }
            else if (enemyName == "rat")
            {
                Invoke("Rat", 2); ;
            }
            myturn = !myturn;
        }


    }

    public void Attack()
    {
        notification.text = enemyName + " terkena " + myDmg + " DMG.";
        enemyHealth = enemyHealth - myDmg;
        myturn = !myturn;
        barrier.SetActive(true);
        attack.interactable = false;
        heal.interactable = false;
        flee.interactable = false;
    }
    public void Heal()
    {
        int potion = Random.Range(10, 20);
        myHealth = myHealth + potion;
        if(myHealth > 100){
            myHealth = 100;
        }
        myturn = !myturn;
        barrier.SetActive(true);
        attack.interactable = false;
        heal.interactable = false;
        flee.interactable = false;
    }
    public void Flee()
    {
        battle.SetActive(false);
        int a = PlayerPrefs.GetInt("map");
        SceneManager.LoadScene(a + 2);

    }

    public void Retry()
    {
        enemyHealth = 100;
        myHealth = 100;
        gameOver.SetActive(false);
        battle.SetActive(true);
    }

    void Bandit()
    {
        enemyDmg = Random.Range(30, 45);
        myHealth = myHealth - enemyDmg;
        notification.text = "Player terkena " + enemyDmg + " DMG.";
        attack.interactable = true;
        heal.interactable = true;
        flee.interactable = true;
        barrier.SetActive(false);
    }
    void Rat()
    {
        enemyDmg = Random.Range(25, 30);
        myHealth = myHealth - enemyDmg;
        notification.text = "Player terkena " + enemyDmg + " DMG.";
        attack.interactable = true;
        heal.interactable = true;
        flee.interactable = true;
        barrier.SetActive(false);

    }
    void Ant()
    {
        enemyDmg = Random.Range(19, 24);
        myHealth = myHealth - enemyDmg;
        notification.text = "Player terkena " + enemyDmg + " DMG.";
        attack.interactable = true;
        heal.interactable = true;
        flee.interactable = true;
        barrier.SetActive(false);

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
