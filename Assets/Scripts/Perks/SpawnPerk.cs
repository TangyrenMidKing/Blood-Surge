using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerk : MonoBehaviour
{
    // an array of perk prefabs
    public ZombieHealth zombieHealth;
    public GameObject[] perks = new GameObject[6];
    public PlayerHealth playerHealth;
    //public GameObject zombie;
    int health;
    int choosePerk;
    bool spawn;
    public static int enemiesKilled;
    int playerCurrentHealth;
    float despawnTime = 20.0f;
    GameObject obj;


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
        playerCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

        health = zombieHealth.GetComponent<ZombieHealth>().getHealth();
        if (health <= 0)
        {
            // if dice roll was successful then a random perk will spawn
            if (spawn)
            {
              
                // Spawns a random perk at the position of the zombie, then destroys the zombie
                obj = Instantiate(perks[choosePerk], transform.position + Vector3.up, perks[choosePerk].transform.rotation);
                Destroy(obj, despawnTime); // despawns the perk after a time, despawnTime
            }
            // destroys the zombie
            Destroy(gameObject);
            ++enemiesKilled;
        }
    }


    // randomly choose a perk
    // this is called in Start, and because all zombies spawn at once then when the players health is at or above 100
    // all these zombies will only spawn the speedbost or shield
    // TODO: so try changing this so that the zombies spawn at intervals instead of all at once or change how this method works
    void RandomlyChoosePerk()
    {
        // doesn't spawn the health heal perk if players health is above 100
        if (playerCurrentHealth > 100)
        {
            Debug.Log("No heals");
            // change this when we add in more perks
            // right now it "rolls" a dice between 1-6 and if the roll is greater than or equal to 3 then spawn the speedboost perk
            choosePerk = Random.Range(1, 6);
        }
        // else anything can spawn
        else
        {
            choosePerk = Random.Range(0, 6);

        }
            

    }

    // "rolls" a dice between 0 and 6 and if the roll was 3 then it will spawn a perk
    // So there is a 1/10 chance of a perk spawning per zombie
    void DiceRoll()
    {
        if(Random.Range(0, 10) == 3)
        {
            spawn = true;
        }
        else
        {
            spawn = false;
        }

    }

    public int getEnemiesKilled()
    {
        return enemiesKilled;
    }
}
