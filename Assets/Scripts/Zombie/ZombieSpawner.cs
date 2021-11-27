using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject boss;

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
            spawnZombies(10);
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberUI.text = "Wave: " + waveNumber;
        enemyCount = GameObject.FindGameObjectsWithTag("BasicZombie").Length
                    + GameObject.FindGameObjectsWithTag("EliteZombie").Length;
        chooseRandomSpawnPosition();

        // starts new wave when enemy count reaches 1 because this also counts the zombie in the "jail", who is unreachable
        if (enemyCount == 2)
        {
            instructions.GetComponent<Text>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
            {
                waveNumber++;
                spawnZombies(waveNumber * 3 + 10);
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
        for (int i = 0; i < numEnemies / 2; i++)
        {
            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
            ++enemyCount;
        }

        for (int i = 0; i < numEnemies / 2; i++)
        {
            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
            ++enemyCount;
        }

        if (waveNumber % 5 == 0)
            spawnEliteZombies(waveNumber / 5);
    }

    void spawnEliteZombies(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(boss, new Vector3(randx, 0, randz), boss.transform.rotation);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRangeOfButton = false;
        }
    }

}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ZombieSpawner : MonoBehaviour
// {
//     public GameObject zombie;
//     public GameObject boss;
//     int enemyCount;
//     int waveNumber;
//     public Text instructions;
//     public Text waveNumberUI;
//     bool inRangeOfButton;



//     // Start is called before the first frame update
//     void Start()
//     {
//         waveNumber = 0;
//         enemyCount = 0;

//         // spawns 10 zombies at start of game
//         if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
//             spawnZombies(10);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         enemyCount = GameObject.FindGameObjectsWithTag("BasicZombie").Length
//                     + GameObject.FindGameObjectsWithTag("EliteZombie").Length;
//         waveNumberUI.text = "Wave: " + waveNumber;

//         // starts new wave when enemy count reaches 1 because this also counts the zombie in the "jail", who is unreachable
//         instructions.GetComponent<Text>().enabled = true;
//         if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
//         {
//             waveNumber++;
//             if (waveNumber % 5 != 0)
//                 spawnZombies(waveNumber * 3 + 10);
//             else
//                 spawnEliteZombies(waveNumber / 5);
//         }
//         else
//         {
//             instructions.GetComponent<Text>().enabled = false;
//         }


//     }


//     // spawns half the zombies at a random position on one part of the map and the other half on another part of the map
//     void spawnZombies(int numEnemies)
//     {
//         for (int i = 0; i < numEnemies / 2; i++)
//         {

//             Instantiate(zombie, GetRandomLocation(), zombie.transform.rotation);
//             ++enemyCount;
//         }

//         StartCoroutine(Coroutine(Random.Range(0, 5)));

//         for (int i = 0; i < numEnemies / 2; i++)
//         {
//             Instantiate(zombie, GetRandomLocation(), zombie.transform.rotation);
//             ++enemyCount;
//         }
//     }

//     IEnumerator Coroutine(int seconds)
//     {
//         yield return new WaitForSeconds(seconds);
//     }

//     void spawnEliteZombies(int numEnemies)
//     {
//         numEnemies++;

//         for (int i = 0; i < numEnemies; i++)
//         {
//             Instantiate(boss, GetRandomLocation(), boss.transform.rotation);
//             ++enemyCount;
//         }
//     }

//     // choose between two areas of the map to spawn zombies on
//     Vector3 GetRandomLocation()
//     {
//         UnityEngine.AI.NavMeshTriangulation navMeshData = UnityEngine.AI.NavMesh.CalculateTriangulation();

//         // Pick the first indice of a random triangle in the nav mesh
//         int t = Random.Range(0, navMeshData.indices.Length - 3);

//         // Select a random point on it
//         Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
//         Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

//         return point;
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.tag == "Player")
//         {
//             inRangeOfButton = true;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.tag == "Player")
//         {
//             inRangeOfButton = false;
//         }
//     }
// }