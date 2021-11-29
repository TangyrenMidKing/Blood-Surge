using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadUI : MonoBehaviour
{
    public ShootGun ShootGun;
    public Text ReloadingTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (ShootGun.GetComponent<ShootGun>().isReloading)
        {
            ReloadingTimer.GetComponent<Text>().enabled = true;

            ReloadingTimer.text = "Reloading";

        }
        else
        {
            ReloadingTimer.GetComponent<Text>().enabled = false;
        }
        
    }
}
