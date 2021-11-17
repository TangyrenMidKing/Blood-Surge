using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    public Rigidbody projectilePrefab;
    public GrabWeapon grabWeapon;
    public AudioClip gunfire;
    AudioSource gunAudio;
    bool shoot=true;
    float bulletSpeed;
    int currentWeapon;
    float audioClipLength;

    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;


  
    enum Weapons
    {
        M4,
        Skorpion,
        Ump,
    }

    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        gunAudio.playOnAwake = false;
        audioClipLength = gunfire.length;
        currentAmmo = maxAmmo;
    }



    // Update is called once per frame
    void Update()
    {
        checkCurrentWeapon();

        if (isReloading){
            return;
        }
        if (currentAmmo <=0)
        {
            StartCoroutine(Reload());
            return;
        }


        // If player presses left mouse button fire a bullet
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LaunchProjectile();
        }
    }

    void OnEnable()
        {
            isReloading = false;
            animator.SetBool("Reloading", false);
        }
    
    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        // sets animation conditions to true and false
        
        animator.SetBool("Reloading", true);
        //countdown timer for animation
        yield return new WaitForSeconds(reloadTime -.25f);
        
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
    // after checking the weapon then assign bulletSpeed
    void checkCurrentWeapon()
    {
        currentWeapon = grabWeapon.GetComponent<GrabWeapon>().getCurrentWeapon(); // gets the index of the weapon in the weaponList array
        switch (currentWeapon)
        {
            case (int)Weapons.M4:
                bulletSpeed = 1500f;
                break;
            case (int)Weapons.Skorpion:
                bulletSpeed = 2000f;
                break;
            case (int)Weapons.Ump:
                bulletSpeed = 500f;
                break;
            default:
                bulletSpeed = 1000f;
                break;
        }
    }

    // Spawns a bullet at the tip of the gun and adds a force to it 
    // Calls a coroutine to delay between shots
    void LaunchProjectile()
    {
        if (shoot)
        {
            var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            //Physics.IgnoreCollision(projectileInstance.GetComponent<Collider>(), firePoint.parent.GetComponent<Collider>());

            //projectileInstance.AddForce(firePoint.forward * .5f, ForceMode.Impulse);

            projectileInstance.AddForce(firePoint.forward * bulletSpeed);

            gunAudio.PlayOneShot(gunfire, 0.2f);

            StartCoroutine(ShootCooldownRoutine());

            currentAmmo--;

            //Destroy(projectilePrefab, audioClipLength);

        }

    }

    // delays time between shots to not have a continous barrage of bullets
    IEnumerator ShootCooldownRoutine()
    {
        shoot = false;
        
        yield return new WaitForSeconds(.5f);
        shoot = true;


    }

}
