using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
   
    int baseHealth = 100;
    int basicZombieDamageTaken = 10;
    int eliteZombieDamageTaken = 15;

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

    // if player runs into a zombie then they lose 10 hp
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            currentHealth -= basicZombieDamageTaken;
        }
        else if (collision.gameObject.CompareTag("EliteZombie"))
        {
            currentHealth -= eliteZombieDamageTaken;
        }
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
}
