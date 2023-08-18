using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class  newgame_button : MonoBehaviour
{
    public void Play()
    {

        SceneManager.LoadScene("Load_Game");
        Time.timeScale = 1f;
    }
 
}
