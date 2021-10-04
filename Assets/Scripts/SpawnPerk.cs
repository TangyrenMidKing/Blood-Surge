using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerk : MonoBehaviour
{
    // an array of perk prefabs
    public GameObject[] perks = new GameObject[3];
    public GameObject zombie;
    int choosePerk;

    // Start is called before the first frame update
    void Start()
    {
        RandomlyChoosePerk();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // check if zombie collides into player then spawn a perk and destroy the zombie
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Spawns a random perk at the position of the zombie, then destroys the zombie
            Instantiate(perks[choosePerk], transform.position, perks[choosePerk].transform.rotation); // this line can be copy/paste into whatever function destroys the zombie
            Destroy(zombie.gameObject);
        }
    }

    // randomly choose a perk
    void RandomlyChoosePerk()
    {
        choosePerk = Random.Range(0, 3);
    }
}
