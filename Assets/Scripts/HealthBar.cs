using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPlayerHealth();
    }

    void DisplayPlayerHealth()
    {

        // Visual change to the color of the health text. Let user know their health is boosted
        if(playerHealth.GetComponent<PlayerHealth>().getHealth() > 100)
        {
            healthBar.color = Color.green;
        }
        else
        {
            healthBar.color = Color.red;
        }
        // Access players current health from PlayerHealth class, then converts it to a string in order to display on UI
        healthBar.text = "Health: " + playerHealth.GetComponent<PlayerHealth>().getHealth().ToString();
    }
}
