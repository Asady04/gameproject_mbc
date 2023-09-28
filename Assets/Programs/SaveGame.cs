using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    private float x, y, z;
    void Start()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        // x = PlayerPrefs.GetFloat("x");
        // y = PlayerPrefs.GetFloat("y");
        // z = PlayerPrefs.GetFloat("z");
        PlayerPrefs.SetInt("map", current - 2);
        // Vector3 LoadPosition = new Vector3(x, y, z);
        // transform.position = LoadPosition;
    }
    public void Save()
    {

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;


        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
    }
}
