using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            paused = true;
            if (Input.GetKey(KeyCode.Escape)){
                paused = false;
            }

        }

        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }
}
