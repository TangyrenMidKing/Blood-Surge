using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
   
    int baseHealth = 100;
    int basicZombieDamageTaken = 10;
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
    }

    // If player runs into healthboost this changes player's current health to be twice their base health, then destroys healthboost
    private void OnTriggerEnter(Collider other)
    {
        int healthBoost = baseHealth * 2;
        if (other.CompareTag("HealthBoost"))
        {
            currentHealth = healthBoost;
            Destroy(other.gameObject);
        }
    }
}
