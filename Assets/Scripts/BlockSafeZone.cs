using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSafeZone : MonoBehaviour
{
    public GameObject player;
    public ZombieSpawner enemyCount;
    public int numEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numEnemies = enemyCount.GetComponent<ZombieSpawner>().enemyCount;

        if(numEnemies > 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        
    }
}
