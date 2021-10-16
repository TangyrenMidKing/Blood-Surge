using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public Gun gun;
    public int shootButton;
    public KeyCode reloadKey;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(shootButton)) {
            gun.Shoot();
        }
        
        if(Input.GetKeyDown(reloadKey)) {
            gun.Reload();
        }
    }
}