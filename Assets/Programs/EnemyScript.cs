using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public bool flip;
    public float speed;
    void Update()
    {
        // Vector3 scale = transform.localState;

        // if (player.transform.position.x > transform.position.x || player.transform.position.y > transform.position.y)
        // {
        //     scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        //     scale.y = Mathf.Abs(scale.y) * -1 * (flip ? -1 : 1);
        //     // transform.Translate(speed * Time.deltaTime);
        // }
        // else
        // {
        //     scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        //     scale.y = Mathf.Abs(scale.y) * (flip ? -1 : 1);
        //     // transform.Translate(speed * Time.deltaTime);
        // }

    }
}
