using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Map1");
        Time.timeScale = 1f;
    }
    public void Load_Game()
    {
        SceneManager.LoadScene("Load_Game");
        Time.timeScale = 1f;
    }
    public void New_Game()
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


}
