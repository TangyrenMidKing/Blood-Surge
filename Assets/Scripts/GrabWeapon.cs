using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public WeaponList weaponList;
    bool inRangeOfWeapon = false;
    int mainWeapon = 0;
    static int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        // Sets all but the one weapon to be inactive
        for(int i = 1; i < weaponList.weaponArray.Length; i++)
        {
            weaponList.weaponArray[i].SetActive(false);
        }
        currentWeapon = mainWeapon;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && inRangeOfWeapon)
        {
            switchWeapon();
        }
    }

    // NOTE: The weapons are based on the position in the WeaponsList Array. So becareful changing them here and there. 
    // Gets the tag of the weapon and sets that weapon to be active. Sets the previous weapon the player was holding to be inactive
    void switchWeapon()
    {
        switch (gameObject.tag)
        {
            // NOTE: For each case we can add a conditional to make sure the player kills a certain number of zombies to get the gun.
            case "M4":
                weaponList.weaponArray[currentWeapon].SetActive(false);
                currentWeapon = 0; // The position of the M4 weapon in the WeaponList Array
                break;

            case "Skorpion":
                weaponList.weaponArray[currentWeapon].SetActive(false);
                currentWeapon = 1; // The position of the Skorpion weapon in the WeaponList Array
                break;

            case "Ump":
                weaponList.weaponArray[currentWeapon].SetActive(false);
                currentWeapon = 2; // The position of the Ump weapon in the WeaponList Array
                break;

            default:
                break;
        }
        weaponList.weaponArray[currentWeapon].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRangeOfWeapon = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRangeOfWeapon = false;
        }
    }

}
