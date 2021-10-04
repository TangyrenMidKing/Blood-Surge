using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public GameObject weaponOnWall = null;
    bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            Debug.Log("Grabbed the weapon!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

}
