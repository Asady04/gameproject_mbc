using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationScript : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }
    public void Play()
    {
        SceneManager.LoadScene("Map1");
        Time.timeScale = 1f;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Load_Game");
        Time.timeScale = 1f;
    }
    public void NewGame()
    {
        SceneManager.LoadScene("New_Game");
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    public void Option()
    {
        SceneManager.LoadScene("Option");
        Time.timeScale = 1f;
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Exit");
        Time.timeScale = 1f;
    }
    public void ConfirmExit()
    {
        Application.Quit();
        Debug.Log("Game Ended");
    }
}
