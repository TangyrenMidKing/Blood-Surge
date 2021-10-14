using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    public void Hit(float damage){
        health -= damage;
    }
}
