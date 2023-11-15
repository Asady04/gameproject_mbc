using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private int map;
    void Start()
    {
        map = PlayerPrefs.GetInt("map", 1);
    }

    public void Load()
    {
        int objective = PlayerPrefs.GetInt("objective");
        if(objective < 1)
        {
            PlayerPrefs.SetInt("objective", 1);
        }
        switch (map)
        {
            case 1:
                SceneManager.LoadScene("Depok");
                break;
            case 2:
                SceneManager.LoadScene("NewBandung");
                break;
            case 3:
                SceneManager.LoadScene("DepokHancur");
                break;
            case 4:
                SceneManager.LoadScene("Pelabuhan");
                break;
            default:
                break;
        }
        Time.timeScale = 1f;
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("map", 1);
        PlayerPrefs.SetInt("objective", 1);
        SceneManager.LoadScene("Depok");
        PlayerPrefs.SetFloat("x", 0);
        PlayerPrefs.SetFloat("y", 0);
        PlayerPrefs.SetFloat("z", 0);
        Time.timeScale = 1f;
    }

}
