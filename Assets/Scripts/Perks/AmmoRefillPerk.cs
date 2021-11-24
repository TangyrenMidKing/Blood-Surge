using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRefillPerk : MonoBehaviour
{
    public bool refillAmmo = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            refillAmmo = true;
            StartCoroutine(RefillAmmoCountDownRoutine());


        }
    }
    IEnumerator RefillAmmoCountDownRoutine()
    {
        yield return null;
        refillAmmo = false;
    }
}
