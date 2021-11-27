using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabWeapon : MonoBehaviour
{
    public WeaponList weaponList;
    public Text instructions;
    bool inRangeOfWeapon = false;
    int mainWeapon = 0;
    static int currentWeapon;
    public SpawnPerk spawnPerk;
    public int enemiesKilled;
    public Text enemiesKilledUI;

    // Start is called before the first frame update
    void Start()
    {
        // Sets all but the one weapon to be inactive
        for(int i = 1; i < weaponList.weaponArray.Length; i++)
        {
            weaponList.weaponArray[i].SetActive(false);
        }
        currentWeapon = mainWeapon;
        stopDisplayingInstructionsUI();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesKilled = spawnPerk.GetComponent<SpawnPerk>().getEnemiesKilled();
        if (Input.GetKeyDown(KeyCode.E) && inRangeOfWeapon)
        {
            changeWeapon();
        }
    }

    // NOTE: The weapons are based on the position in the WeaponsList Array. So becareful changing them here and there. 
    // Gets the tag of the weapon and sets that weapon to be active. Sets the previous weapon the player was holding to be inactive
    void changeWeapon()
    {
        switch (gameObject.tag)
        {
            case "Handgun":
                weaponList.weaponArray[currentWeapon].SetActive(false);
                currentWeapon = 0;
                break;

            case "M4":
                if(enemiesKilled >= 10)
                {
                    weaponList.weaponArray[currentWeapon].SetActive(false);
                    currentWeapon = 1; // The position of the M4 weapon in the WeaponList Array
                }
                break;

            case "Skorpion":
                // if the player killed 30 or more enemies then allow the player to grab this weapon
                if(enemiesKilled >= 30)
                {
                    weaponList.weaponArray[currentWeapon].SetActive(false);
                    currentWeapon = 2; // The position of the Skorpion weapon in the WeaponList Array
                }
                break;

            case "Ump":
                if(enemiesKilled >= 50)
                {
                    weaponList.weaponArray[currentWeapon].SetActive(false);
                    currentWeapon = 4; // The position of the Ump weapon in the WeaponList Array
                }
                break;

            default:
                break;
        }
        weaponList.weaponArray[currentWeapon].SetActive(true);
    }

    // returns the index of the weapon in the weaponList array
    public int getCurrentWeapon()
    {
        return currentWeapon;
    }

    // dispalys either the restrictions on each weapon until it unlocks or 
    // how the player can grab the weapon
    void displayingInstructionsUI()
    {
        enemiesKilledUI.GetComponent<Text>().enabled = true;
        

        switch (gameObject.tag)
        {
            case "Handgun":
                instructions.GetComponent<Text>().enabled = true;
                enemiesKilledUI.GetComponent<Text>().enabled = false;
                break;

            case "M4":
                if(enemiesKilled < 10)
                {
                    instructions.GetComponent<Text>().enabled = false;
                    enemiesKilledUI.text = "Kill " + (10 - enemiesKilled) + " enemies to unlock";
                }
                else
                {
                    // if the player has killed 30 enemies then tell the player how to grab the weapon
                    instructions.GetComponent<Text>().enabled = true;
                    enemiesKilledUI.GetComponent<Text>().enabled = false;
                }

                break;

            case "Skorpion":
                // if the player has not yet killed 30 enemies then display how many more enemies the player
                // needs to kill to unlock the weapon
                if(enemiesKilled < 30)
                {
                    instructions.GetComponent<Text>().enabled = false;
                    enemiesKilledUI.text = "Kill " + (30 - enemiesKilled) + " enemies to unlock";
                }
                else
                {
                    // if the player has killed 30 enemies then tell the player how to grab the weapon
                    instructions.GetComponent<Text>().enabled = true;
                    enemiesKilledUI.GetComponent<Text>().enabled = false;
                }
                break;

            case "Ump":
                if (enemiesKilled < 50)
                {
                    instructions.GetComponent<Text>().enabled = false;
                    enemiesKilledUI.text = "Kill " + (50 - enemiesKilled) + " enemies to unlock";
                }
                else
                {
                    instructions.GetComponent<Text>().enabled = true;
                    enemiesKilledUI.GetComponent<Text>().enabled = false;
                }
                break;

            default:
                break;
        }
    }

    // stops displaying "press e to grab weapon"
    void stopDisplayingInstructionsUI()
    {
        enemiesKilledUI.GetComponent<Text>().enabled = false;
        instructions.GetComponent<Text>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            displayingInstructionsUI();
            inRangeOfWeapon = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            stopDisplayingInstructionsUI();
            inRangeOfWeapon = false;
        }
    }

}
