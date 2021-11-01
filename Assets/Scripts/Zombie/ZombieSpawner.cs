using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public Text instructions;
    public Text waveNumberUI;
    float randx, randz, elrandx, elrandz;
    int chooseSpawnPos;
    public int enemyCount;
    public int waveNumber;
    bool spawn;
    bool inRangeOfButton;



    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        enemyCount = 0;
        //waveNumberUI.text = "Wave: 1";
        chooseRandomSpawnPosition();

        // spawns 10 zombies at start of game
        if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
            spawnZombies(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberUI.text = "Wave: " + waveNumber;
        enemyCount = GameObject.FindGameObjectsWithTag("BasicZombie").Length;
        chooseRandomSpawnPosition();

        // starts new wave when enemy count reaches 1 because this also counts the zombie in the "jail", who is unreachable
        if (enemyCount == 1) 
        {
            instructions.GetComponent<Text>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
            {
                waveNumber++;
                spawnZombies(waveNumber);
            }

        }
        else
        {
            instructions.GetComponent<Text>().enabled = false;
        }

    }


    // spawns half the zombies at a random position on one part of the map and the other half on another part of the map
    void spawnZombies(int numEnemies)
    {

        numEnemies *= 10;
        for (int i = 0; i < numEnemies/2; i++)
        {
            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
            ++enemyCount;
        }

        for (int i = 0; i < numEnemies/2; i++)
        {
            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
            ++enemyCount;
        }
    }


    // choose between two areas of the map to spawn zombies on
    void chooseRandomSpawnPosition()
    {
        chooseSpawnPos = Random.Range(0, 2);

        // lower ramp deadend area
        randx = Random.Range(-6f, 6f);
        randz = Random.Range(-4f, 3f);

        // upper ramp deadend area
        elrandx = Random.Range(62f, 70f);
        elrandz = Random.Range(-4f, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRangeOfButton = true;
        }
    }

}
