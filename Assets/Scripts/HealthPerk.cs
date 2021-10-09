using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerk : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerHealth playerBaseHealth;
    public GameObject healthPickup;
    int playersCurrentHealth;
    int baseHealth;

    // Start is called before the first frame update
    void Start()
    {
        baseHealth = playerHealth.GetComponent<PlayerHealth>().getBaseHealth();
    }

    // Update is called once per frame
    void Update()
    {

        playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

    }

    // check for collision with player then determines health pickup type
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkHealthPickupType();
        }
    }

    // checks health pickup then applies the appropiate perk to player
    void checkHealthPickupType()
    {
        if (healthPickup.gameObject.tag == "HealthBoost")
        {
            applyHealthBoost();
        }
        if (healthPickup.gameObject.tag == "HealthHeal" && playersCurrentHealth < 100)
        {
            applyHealthHeal();
        }
    }

    // applies a health boost up to twice that as the players base health
    void applyHealthBoost()
    {
        int healthBoost = baseHealth * 2;
        playersCurrentHealth = healthBoost;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
        Destroy(healthPickup.gameObject);
    }

    // applies a heal to player up to a cap of players base health
    void applyHealthHeal()
    {
        int healthHeal = 50;
        playersCurrentHealth += healthHeal;
        playersCurrentHealth -= playersCurrentHealth % baseHealth; // this line caps the health gained at base health (100)
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
        Destroy(healthPickup.gameObject);
    }
}
