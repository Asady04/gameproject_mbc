using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class  Load_Game : MonoBehaviour
{
    public void Back()
    {

        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f;
    }
 
}
