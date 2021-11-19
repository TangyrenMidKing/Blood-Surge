using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject boss;
    float randx, randz, elrandx, elrandz;
    int chooseSpawnPos;
    [SerializeField]
    int enemyCount;
    int waveNumber;
    bool spawn;



    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        enemyCount = 0;

        chooseRandomSpawnPosition();
        // spawns 10 zombies at start of game
        spawnEliteZombies(10);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("BasicZombie").Length
                    + GameObject.FindGameObjectsWithTag("EliteZombie").Length;
        chooseRandomSpawnPosition();

        // starts new wave when enemy count reaches 1 because this also counts the zombie in the "jail", who is unreachable
        if (enemyCount == 2 && waveNumber % 5 != 0)
        {
            spawnZombies(waveNumber * 3 + 10);
            waveNumber++;
        }
        else if (enemyCount == 2)
        {
            spawnEliteZombies(waveNumber / 5);
            waveNumber++;
        }
    }


    // spawns half the zombies at a random position on one part of the map and the other half on another part of the map
    void spawnZombies(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(zombie, GetRandomLocation(), zombie.transform.rotation);
            ++enemyCount;
        }
    }

    void spawnEliteZombies(int numEnemies)
    {
        numEnemies++;

        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(boss, GetRandomLocation(), boss.transform.rotation);
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

    Vector3 GetRandomLocation()
    {
        UnityEngine.AI.NavMeshTriangulation navMeshData = UnityEngine.AI.NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }
}