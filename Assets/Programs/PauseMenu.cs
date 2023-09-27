using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause_Menu : MonoBehaviour
{
    bool isPaused = false;
    public bool GetIsPaused() { return isPaused; }

    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject optionMenu = null;

    void Update()
    {   if(isPaused == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }

        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }

    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Options()
    {
        optionMenu.SetActive(true);
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
    }

    


}


