using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class  loadgame_button : MonoBehaviour
{
    public void Play()
    {

        SceneManager.LoadScene("New_Game");
        Time.timeScale = 1f;
    }
 
}
