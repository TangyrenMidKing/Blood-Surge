using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadUI : MonoBehaviour
{
    public ShootGun ShootGun;
    public GrabWeapon grabWeapon;
    public Text ReloadingTimer;

    // Start is called before the first frame update
    void Start()
    {

    }
    enum Weapons
    {
        Handgun,
        M4,
        Skorpion,
        Ump,
    }

    // Update is called once per frame
    void Update()
    {
        int currentWeapon = grabWeapon.GetComponent<GrabWeapon>().getCurrentWeapon();
         switch (currentWeapon)
        {
            case (int)Weapons.Handgun:
                if (ShootGun.GetComponent<ShootGun>().isReloading)
        {
            ReloadingTimer.GetComponent<Text>().enabled = true;

            ReloadingTimer.text = "Reloading";

        }
        else
        {
            ReloadingTimer.GetComponent<Text>().enabled = false;
        }

                break;

            case (int)Weapons.M4:
                if (ShootGun.GetComponent<ShootGun>().isReloading)
        {
            ReloadingTimer.GetComponent<Text>().enabled = true;

            ReloadingTimer.text = "Reloading";

        }
        else
        {
            ReloadingTimer.GetComponent<Text>().enabled = false;
        }

                break;

            case (int)Weapons.Skorpion:
                if (ShootGun.GetComponent<ShootGun>().isReloading)
        {
            ReloadingTimer.GetComponent<Text>().enabled = true;

            ReloadingTimer.text = "Reloading";

        }
        else
        {
            ReloadingTimer.GetComponent<Text>().enabled = false;
        }

                break;

            case (int)Weapons.Ump:
                if (ShootGun.GetComponent<ShootGun>().isReloading)
        {
            ReloadingTimer.GetComponent<Text>().enabled = true;

            ReloadingTimer.text = "Reloading";

        }
        else
        {
            ReloadingTimer.GetComponent<Text>().enabled = false;
        }

                break;

            default:
                if (ShootGun.GetComponent<ShootGun>().isReloading)
        {
            ReloadingTimer.GetComponent<Text>().enabled = true;

            ReloadingTimer.text = "Reloading";

        }
        else
        {
            ReloadingTimer.GetComponent<Text>().enabled = false;
        }

                break;
        }
        //  if (ShootGun.GetComponent<ShootGun>().isReloading)
        // {
        //     ReloadingTimer.GetComponent<Text>().enabled = true;

        //     ReloadingTimer.text = "Reloading";

        // }
        // else
        // {
        //     ReloadingTimer.GetComponent<Text>().enabled = false;
        // }

    }
}
