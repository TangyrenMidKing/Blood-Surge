using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRespawn : MonoBehaviour
{
    public ShootGun shootgun;
    public GameObject ammoRefill;
    public ZombieSpawner zombieSpawner;
    public GrabWeapon grabWeapon;
    public int _ammo;
    int waveNum;
    int currentWeapon;

    enum Weapons
    {
        Handgun,
        M4,
        Skorpion,
        Ump,
        Minigun
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentWeapon = grabWeapon.GetComponent<GrabWeapon>().getCurrentWeapon(); // gets the index of the weapon in the weaponList array

        switch (currentWeapon)
        {
            case (int)Weapons.Handgun:
                _ammo = shootgun.ammo;
                break;

            case (int)Weapons.M4:
                _ammo = shootgun.ammo;
                break;

            case (int)Weapons.Skorpion:
                _ammo = shootgun.ammo;
                break;

            case (int)Weapons.Ump:
                _ammo = shootgun.ammo;
                break;

            case (int)Weapons.Minigun:
                break;

            default:
                break;
        }


        waveNum = zombieSpawner.waveNumber;
        _ammo = shootgun.ammo;

        if(_ammo <= 50 && waveNum>0)
        {
            Instantiate(ammoRefill, this.gameObject.transform.position + Vector3.up, ammoRefill.transform.rotation);
        }
    }
}
