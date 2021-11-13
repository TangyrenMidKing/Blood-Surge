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
            healthBar.color = new Color(.41f,.04f,.96f);
        }
        

        // When the players health reaches zero there is a small delay before switching to the main menu scene.
        // Because of that the players health can go into the negatives, so to stop that we can hardcode the health display to zero
        if(playerHealth.GetComponent<PlayerHealth>().getHealth() <= 0)
            healthBar.text = "Health: " + 0;
        else
            healthBar.text = "Health: " + playerHealth.GetComponent<PlayerHealth>().getHealth().ToString(); // Access players current health from PlayerHealth class, then converts it to a string in order to display on UI
    }
}
