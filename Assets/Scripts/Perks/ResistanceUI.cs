using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text resistanceUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the player has the speed boost then show the text UI
        // TODO: Add a timer???
         
        if (playerHealth.GetComponent<PlayerHealth>().getHasResistancePerk())
        {
            resistanceUI.GetComponent<Text>().enabled = true;

            resistanceUI.text = "Resistance Applied";

        }
        else
        {
            resistanceUI.GetComponent<Text>().enabled = false;
        }


    }
}
