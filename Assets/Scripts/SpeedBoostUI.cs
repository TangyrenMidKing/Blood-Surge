using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoostUI : MonoBehaviour
{
    public PlayerController playerController;
    public Text speedBoostTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has the speed boost then show the text UI
        // TODO: Add a timer???

        if (playerController.GetComponent<PlayerController>().hasBoostSpeed)
        {
            speedBoostTimer.GetComponent<Text>().enabled = true;

            speedBoostTimer.text = "Speed Boost Applied";

        }
        else
        {
            speedBoostTimer.GetComponent<Text>().enabled = false;
        }
        

    }
}
