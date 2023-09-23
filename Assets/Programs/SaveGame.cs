using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    private float x, y, z;
    void Start()
    {
        // x = PlayerPrefs.GetFloat("x");
        // y = PlayerPrefs.GetFloat("y");

        // Vector3 LoadPosition = new Vector3(x, y, 0);
        // transform.position = LoadPosition;
    }
    public void Save()
    { 
        int current = SceneManager.GetActiveScene().buildIndex;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        PlayerPrefs.SetInt("map", current-2);
        
        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
    }
}
