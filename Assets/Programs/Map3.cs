using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Map3 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Back()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1f; 
    }

}
