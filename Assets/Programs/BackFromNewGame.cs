using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back_NewGame: MonoBehaviour
{
    public void play()
    {

        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }

}