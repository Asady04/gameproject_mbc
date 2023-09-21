using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    private int map;
    void Start()
    {
        map = PlayerPrefs.GetInt("map", 1);
    }

    public void LoadGame()
    {
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
        SceneManager.LoadScene("New_Game");
        Time.timeScale = 1f;
    }
    // void Update()
    // {

    // }
}
