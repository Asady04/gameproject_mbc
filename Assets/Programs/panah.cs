using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panah : MonoBehaviour
{
    private int backSceneToLoad;
    private void Start()
    {
        backSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(backSceneToLoad);
    }
}
