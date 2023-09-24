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
    public void NewGame()
    {
        SceneManager.LoadScene("NewGame");
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
    private int nextSceneToLoad;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
