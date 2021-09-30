using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject zombie;
    int playersCurrentHealth;
    int eliteZombieDamage;
    int basicZombieDamage;

    // Start is called before the first frame update
    void Start()
    {
        basicZombieDamage = 10;
        eliteZombieDamage = 15;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayersCurrentHealth();
    }

    void GetPlayersCurrentHealth()
    {
        playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();
    }

    // updates player health depending on what kind of zombie attacks
    void ZombieAttacks(int damage)
    {
        playersCurrentHealth -= damage;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
    }

    // checks the tag of the game object this script is attached to
    void CheckZombieType()
    {
        switch (zombie.gameObject.tag)
        {
            case "BasicZombie":
                ZombieAttacks(basicZombieDamage);
                break;

            case "EliteZombie":
                ZombieAttacks(eliteZombieDamage);
                break;

            default:
                break;
        }
    }

    // check if zombie collides into player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckZombieType();
        }
    }

}
