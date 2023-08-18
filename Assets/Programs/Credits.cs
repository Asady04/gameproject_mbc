using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class credit_button : MonoBehaviour
{
    public void play()
    {

        SceneManager.LoadScene("Credits");
        Time.timeScale = 1f;
    }

}