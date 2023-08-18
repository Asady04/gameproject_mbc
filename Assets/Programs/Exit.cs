using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exit_button : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Exit");
        Time.timeScale = 1f;
    }
}

