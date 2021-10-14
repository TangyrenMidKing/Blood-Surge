using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other){
        Target target = other.gameObject.GetComponent<Target>();
        if(target != null){
            target.Hit(damage);
            Destroy(gameObject);
        }
    }
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
