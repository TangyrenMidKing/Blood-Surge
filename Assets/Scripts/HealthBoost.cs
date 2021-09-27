using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    int healthBoost = 200;
    int _health = 0;

    public int GetHealthBoost()
    {
        return _health + healthBoost;
    }
    public void SetHealthBoost(int health)
    {
        _health = health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
