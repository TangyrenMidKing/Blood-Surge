using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    bool hasResistancePerk = false;
    int baseHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    // (Getter) Allows other classes to access the players current health
    public int getHealth()
    {
        return currentHealth;
    }

    // (Setter) Allows other classes to change players current health
    public void setHealth(int health)
    {
        currentHealth = health;
    }

    // (Getter) Allows other classes to access the players base health
    public int getBaseHealth()
    {
        return baseHealth;
    }

    public bool getHasResistancePerk()
    {
        if (hasResistancePerk)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Resistance") && !hasResistancePerk)
        {
            hasResistancePerk = true;
            Destroy(other.gameObject);
            StartCoroutine(ResistanceCountdownRoutine());
        }
    }

    // Coroutine used as a countdown timer. Applies speed boost to character for 7 seconds
    IEnumerator ResistanceCountdownRoutine()
    {
        yield return new WaitForSeconds(20f);

        hasResistancePerk = false;

    }
}
