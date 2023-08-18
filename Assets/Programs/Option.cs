using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class option_button : MonoBehaviour
{
    public void Play()
    {
        
        SceneManager.LoadScene("Option");
        Time.timeScale = 1f;
    }
}
