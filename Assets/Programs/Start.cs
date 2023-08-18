using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start_button : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Map1");
        Time.timeScale = 1f;
    }
}