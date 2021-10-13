using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform player;
    public Transform zombie;
    public int playersCurrentHealth;
    public int zombieDamage;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter").transform;
        zombie = GameObject.Find("ZombieObj").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

            if (Vector3.Distance(player.position, zombie.position) <= attackRange)
                attacks(zombieDamage);
        }
    }

    // updates player health depending on what kind of zombie attacks
    private void attacks(int damage)
    {
        playersCurrentHealth -= zombieDamage;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
    }
}
