using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePerks : MonoBehaviour
{
    public GameObject perk;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RotatePerk();
    }

    // Rotates the perk to be constantly facing the player
    void RotatePerk()
    {
        transform.LookAt(player);

        // This is because the forward vector of the model for "health boost" is different than other models...
        // So it needs it's rotation corrected
        if (perk.CompareTag("HealthBoost"))
        {
            transform.Rotate(new Vector3(1, 0, 0), 90);
        }
    }
}
