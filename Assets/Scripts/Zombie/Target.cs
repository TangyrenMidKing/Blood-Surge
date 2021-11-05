using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //  ?????????????
    int health;
    public ZombieHealth zombieHealth;
    int currentHealth;

    void Update()
    {
        currentHealth = zombieHealth.GetComponent<ZombieHealth>().getHealth();
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(int damage)
    {
        health = currentHealth;
        health -= damage;
        zombieHealth.GetComponent<ZombieHealth>().setHealth(health);
    }
}
