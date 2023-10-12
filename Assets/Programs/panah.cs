using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panah : MonoBehaviour
{
    private int backSceneToLoad;
    [SerializeField] GameObject pause = null;
    [SerializeField] GameObject hud = null;
    [SerializeField] GameObject loading = null;
    private void Start()
    {

        backSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pause.SetActive(false);
        hud.SetActive(false);
        loading.SetActive(true);
        SceneManager.LoadScene(backSceneToLoad);
    }
}
