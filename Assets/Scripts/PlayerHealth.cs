using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 
    int baseHealth = 100;

    [SerializeField]
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // If player runs into healthboost this changes player's current health to be twice their base health, then destroys healthboost
    // If player runs into healthheal this adds health to players current health up to a cap of 100
    private void OnTriggerEnter(Collider other)
    {
        int healthBoost = baseHealth * 2;
        int healthHeal = 50;
        if (other.CompareTag("HealthBoost"))
        {
            currentHealth = healthBoost;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("HealthHeal") && currentHealth != 100) 
        {
            currentHealth += healthHeal;
            currentHealth -= currentHealth % 100; // this line caps the health gained at 100
            Destroy(other.gameObject);
        }
    }


    // (Getter) Allows other classes to access the players current health
    public int getHealth()
    {
        return currentHealth;
    }

    // (Setter) Allows other classes to change players current health
    public void setHealth(int health)
    {
        currentHealth = health;
    }
}
