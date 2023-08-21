using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void Yes()
    {
        Application.Quit();
        Debug.Log("Game Ended");
    }
    public void Back()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }
}

