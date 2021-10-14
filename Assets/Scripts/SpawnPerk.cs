using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerk : MonoBehaviour
{
    // an array of perk prefabs
    public ZombieHealth zombieHealth;
    public GameObject[] perks = new GameObject[3];
    public GameObject zombie;
    int choosePerk;
    bool spawn;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
        RandomlyChoosePerk();
        DiceRoll();
    }

    // Update is called once per frame
    void Update()
    {
        health = zombieHealth.GetComponent<ZombieHealth>().getHealth();
        if (health <= 0)
        {
            // if dice roll was successful then a random perk will spawn
            if (true)
            {
                // Spawns a random perk at the position of the zombie, then destroys the zombie
                Instantiate(perks[choosePerk], transform.position + Vector3.up, perks[choosePerk].transform.rotation); // this line can be copy/paste into whatever function destroys the zombie
            }
            Destroy(zombie.gameObject);
        }
    }

    // check if zombie collides into player then spawn a perk and destroy the zombie
    private void OnCollisionEnter(Collision collision)
    {
        // if (health <= 0)
        // {
        //     // if dice roll was successful then a random perk will spawn
        //     if (spawn)
        //     {
        //         // Spawns a random perk at the position of the zombie, then destroys the zombie
        //         Instantiate(perks[choosePerk], transform.position + Vector3.up, perks[choosePerk].transform.rotation); // this line can be copy/paste into whatever function destroys the zombie
        //     }
        //     //Destroy(zombie.gameObject);
        // }
    }

    // randomly choose a perk
    void RandomlyChoosePerk()
    {
        choosePerk = Random.Range(0, 3);
    }

    // "rolls" a dice between 0 and 6 and if the roll was 3 then it will spawn a perk
    // So there is a 1/6 chance of a perk spawning per zombie
    void DiceRoll()
    {
        if(Random.Range(0, 7) == 3)
        {
            spawn = true;
        }
        else
        {
            spawn = false;
        }

    }
}
