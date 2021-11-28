using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerk : MonoBehaviour
{
    public GrabWeapon currentWeapon;

    public ShootGun M4ShootGun;
    public ShootGun SkorpionShootGun;
    public ShootGun UmpShootGun;
    public ShootGun HandgunShootGun;
    public ZombieHealth zombieHealth;
    // an array of perk prefabs
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
    public int _ammo;

    enum Weapons
    {
        Handgun,
        M4,
        Skorpion,
        Ump,
    }

    // Start is called before the first frame update
    void Start()
    {
        
        spawn = false;
        //RandomlyChoosePerk();
        DiceRoll();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentWeapon.getCurrentWeapon())
        {
            case (int)Weapons.Handgun:
                _ammo = HandgunShootGun.ammo;
                break;
            case (int)Weapons.M4:
                _ammo = M4ShootGun.ammo;
                break;
            case (int)Weapons.Skorpion:
                _ammo = SkorpionShootGun.ammo;
                break;
            case (int)Weapons.Ump:
                _ammo = UmpShootGun.ammo;
                break;
        }


        RandomlyChoosePerk();

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
    void RandomlyChoosePerk()
    {

        // if the player has boosted health then we don't need to spawn any of the health perks
        if (playerCurrentHealth >= 150)
        {
            // if the player doesn't have a lot of ammo left then spawn more ammo perks
            if (_ammo <= 100)
            {
                choosePerk = Random.Range(4, 6);
            }
            // otherwise if the player still has ammo then anything but the health perks will spawn
            else
            {
                choosePerk = Random.Range(2, 6);
            }
        }
        // doesn't spawn the health heal perk if players health is above 100
        else if (playerCurrentHealth > 100)
        {
            // if the player doesn't have a lot of ammo left then spawn more ammo perks
            if (_ammo <= 100)
            {
                choosePerk = Random.Range(4, 6);
            }
            // otherwise if the player still has ammo then anything but the health heal perks will spawn
            else
            {
                choosePerk = Random.Range(2, 6);
            }
        }
        // if the player has little health remaining then spawn either of the health perks or the resistance perk or the speedboost perk
        else if (playerCurrentHealth < 100)
        {
            choosePerk = Random.Range(0, 4);
        }
        // else anything can spawn
        else
        {
            choosePerk = Random.Range(0, 6);

        }
            

    }

    // "rolls" a dice between 0 and 6 and if the roll was 3 then it will spawn a perk
    // So there is a 1/20 chance of a perk spawning per zombie
    void DiceRoll()
    {
        if(Random.Range(0, 15) == 3)
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
