using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    AudioSource explosionAudio;
    public AudioClip explosion;
    public GameObject bigExplosion;
    public GameObject zombie;
    public GameObject boss;
    public GameObject block;
    public Text instructions;
    public Text waveNumberUI;
    float randx, randz, elrandx, elrandz, lcrandx, lcrandz, warandx, warandz, rcrandx, rcrandz, werandx, werandz;
    float mirandx, mirandz;
    int chooseSpawnPos;
    public int enemyCount;
    public int waveNumber;
    int divider;
    bool spawn;
    bool inRangeOfButton;
    public float timeBetweenSpawn = 3f;



    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
        explosionAudio.playOnAwake = false;

        waveNumber = 0;
        enemyCount = 0;
        //waveNumberUI.text = "Wave: 1";
        chooseRandomSpawnPosition();

        /*
        // spawns 10 zombies at start of game
        if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
        {
            spawnZombies(10);
        }*/

        
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberUI.text = "Wave: " + waveNumber;
        enemyCount = GameObject.FindGameObjectsWithTag("BasicZombie").Length
                    + GameObject.FindGameObjectsWithTag("EliteZombie").Length;
        chooseRandomSpawnPosition();

        // starts new wave when enemy count reaches 2 because this also counts the zombie and elite in the "jail", who is unreachable
        if (enemyCount == 2)
        {
            instructions.GetComponent<Text>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && inRangeOfButton)
            {
                if (waveNumber == 0)
                {
                    var explosionInstance = Instantiate(bigExplosion);
                    explosionInstance.GetComponent<ParticleSystem>().Play();
                    explosionAudio.PlayOneShot(explosion, 1f);
                    Destroy(explosionInstance.gameObject, 1.045f);
                }


                Destroy(block.gameObject);
 
                waveNumber++;
                spawnZombies((waveNumber*2) +10);
            }

        }
        else
        {
            instructions.GetComponent<Text>().enabled = false;
        }

    }

    IEnumerator SpawnRoutine(int numEnemies)
    {
        int i = 0;
 
        while (i < numEnemies)
        {
            if (enemyCount < (numEnemies/2))
            {
                switch (Random.Range(0, 7))
                {
                    case 0:
                        Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                        if(waveNumber>=5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                        }
                        else if (waveNumber>= 15)
                        {
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(randx, 0, randz), zombie.transform.rotation);
                        }

                        break;
                    case 1:
                        Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                        if (waveNumber >= 5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                        }
                        else if (waveNumber >= 15)
                        {
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(elrandx, 2.08f, elrandz), zombie.transform.rotation);
                        }
                        break;
                    case 2:
                        Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                        if (waveNumber >= 5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                        }
                        else if (waveNumber >= 15)
                        {
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(lcrandx, 2.08f, lcrandz), zombie.transform.rotation);
                        }
                        break;
                    case 3:
                        Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                        if (waveNumber >= 5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                        }
                        else if (waveNumber >= 15)
                        {
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(warandx, 2.08f, warandz), zombie.transform.rotation);
                        }
                        break;
                    case 4:
                        Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                        if (waveNumber >= 5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                        }
                        else if (waveNumber >= 15)
                        {
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(rcrandx, 2.08f, rcrandz), zombie.transform.rotation);
                        }
                        break;
                    case 5:
                        Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                        if (waveNumber >= 5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                        }
                        else if (waveNumber >= 15)
                        {
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(werandx, 2.08f, werandz), zombie.transform.rotation);
                        }
                        break;
                    case 6:
                        Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                        if (waveNumber >= 5 && waveNumber < 10)
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                        else if(waveNumber>=10 && waveNumber < 15)
                        {
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                        }
                        else if (waveNumber >= 15)
                        {
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                            Instantiate(zombie, new Vector3(mirandx, 2.08f, mirandz), zombie.transform.rotation);
                        }
                        break;
                }

                ++i;
                yield return new WaitForSeconds(timeBetweenSpawn);
            }
            yield return null;
        }
    }

    // spawns half the zombies at a random position on one part of the map and the other half on another part of the map
    void spawnZombies(int numEnemies)
    {

        StartCoroutine(SpawnRoutine(numEnemies));

        if (waveNumber % 5 == 0)
            spawnEliteZombies(waveNumber / 5);
    }

    void spawnEliteZombies(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            switch (Random.Range(0, 7))
            {
                case 0:
                    Instantiate(boss, new Vector3(randx, 0, randz), boss.transform.rotation);
                    ++enemyCount;
                    break;
                case 1:
                    Instantiate(boss, new Vector3(elrandx, 2.08f, elrandz), boss.transform.rotation);
                    ++enemyCount;
                    break;
                case 2:
                    Instantiate(boss, new Vector3(lcrandx, 2.08f, lcrandz), boss.transform.rotation);
                    ++enemyCount;
                    break;
                case 3:
                    Instantiate(boss, new Vector3(warandx, 2.08f, warandz), boss.transform.rotation);
                    ++enemyCount;
                    break;
                case 4:
                    Instantiate(boss, new Vector3(rcrandx, 2.08f, rcrandz), boss.transform.rotation);
                    ++enemyCount;
                    break;
                case 5:
                    Instantiate(boss, new Vector3(werandx, 2.08f, werandz), boss.transform.rotation);
                    ++enemyCount;
                    break;
                case 6:
                    Instantiate(boss, new Vector3(mirandx, 2.08f, mirandz), boss.transform.rotation);
                    ++enemyCount;
                    break;
            }

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

        lcrandx = Random.Range(64f, 66f);
        lcrandz = Random.Range(-35f, -50f);

        warandx = Random.Range(13f, 16f);
        warandz = Random.Range(-37f, -47f);

        rcrandx = Random.Range(-5f, -8f);
        rcrandz = Random.Range(-18f, -14f);

        werandx = Random.Range(54f, 61f);
        werandz = Random.Range(11f, 16f);

        mirandx = Random.Range(37f, 43f);
        mirandz = Random.Range(-11f, -17f);
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