using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Option : MonoBehaviour
{
    [SerializeField] GameObject optionPanel = null;
    [SerializeField] GameObject pauseMenu = null;

    void Update()
    {
        Time.timeScale = 0;
        optionPanel.SetActive(true);
    }

    public void Back()
    {
        Time.timeScale = 0;
        optionPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }

    public void Options()
    {

    }


}
