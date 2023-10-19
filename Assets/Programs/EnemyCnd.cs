using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCnd : MonoBehaviour
{
    [SerializeField] GameObject rat = null;
    [SerializeField] GameObject ant = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("objective") == 6){
            ant.SetActive(true);
        }else
        {
            ant.SetActive(false);
        }

        if(PlayerPrefs.GetInt("objective") == 8){
            rat.SetActive(true);
        }else
        {
            rat.SetActive(false);
        }
    }
}
