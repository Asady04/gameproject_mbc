using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapTransition : MonoBehaviour
{
    [SerializeField] GameObject pause = null;
    [SerializeField] GameObject hud = null;
    [SerializeField] GameObject loading = null;
    private int nextSceneToLoad;
    private int objective;
    private int currentMap;
    private void Start()
    {
        objective = PlayerPrefs.GetInt("objective");
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    void Update()
    {
        currentMap = PlayerPrefs.GetInt("map");
        Debug.Log("currentmap:" + currentMap);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        

        if (objective == 4 && currentMap == 1)
        {
            pause.SetActive(false);
            hud.SetActive(false);
            loading.SetActive(true);

            SceneManager.LoadScene(nextSceneToLoad);
        }
        else if (objective == 10 && currentMap == 2)
        {
            pause.SetActive(false);
            hud.SetActive(false);
            loading.SetActive(true);
            SceneManager.LoadScene(nextSceneToLoad);
            PlayerPrefs.SetInt("objective", 11);
        }
        else if (objective == 13 && currentMap == 3)
        {
            pause.SetActive(false);
            hud.SetActive(false);
            loading.SetActive(true);
            SceneManager.LoadScene(nextSceneToLoad);
        }

    }
}
