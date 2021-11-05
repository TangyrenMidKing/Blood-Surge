using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

    public int baseHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
    }


    // Update is called once per frame
    void Update()
    {

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

    public void Hit(int damage)
    {
        currentHealth -= damage;
    }

    // (Getter) Allows other classes to access the players base health
    public int getBaseHealth()
    {
        return baseHealth;
    }
}