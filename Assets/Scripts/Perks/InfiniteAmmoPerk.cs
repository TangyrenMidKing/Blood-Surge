using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteAmmoPerk : MonoBehaviour
{
    public bool hasInfiniteAmmo;
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
        if (other.CompareTag("InfiniteAmmo") && hasInfiniteAmmo != true)
        {
            hasInfiniteAmmo = true;
            Destroy(other.gameObject);
            StartCoroutine(InfiniteAmmoCountDownRoutine());
        }
    }

    IEnumerator InfiniteAmmoCountDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        hasInfiniteAmmo = false;
    }
}
