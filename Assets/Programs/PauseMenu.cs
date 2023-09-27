using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause_Menu : MonoBehaviour
{
    public static bool isPaused;
    public bool GetIsPaused() { return isPaused; }

    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject optionMenu = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc pressed");
            isPaused = !isPaused;

            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
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

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }

    public void Options()
    {
        optionMenu.SetActive(true);
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
    }


}
