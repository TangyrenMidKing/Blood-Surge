using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    public ZombieSpawner zombieSpawner;
    public InfiniteAmmoPerk infiniteAmmoPerk;
    public Transform firePoint;
    public GameObject projectile;
    public Rigidbody projectilePrefab;
    public GrabWeapon grabWeapon;
    public AudioClip gunfire;
    public Text ammoUI;
    AudioSource gunAudio;
    bool shoot=true;
    float bulletSpeed;
    int currentWeapon;
    float audioClipLength;
    public int ammo = 300;
    int waveNum;
    bool hasInfiniteAmmo;
    




    enum Weapons
    {
        M4,
        Skorpion,
        Ump,
    }

    // Start is called before the first frame update
    void Start()
    {
        hasInfiniteAmmo = false;
        gunAudio = GetComponent<AudioSource>();
        gunAudio.playOnAwake = false;
        audioClipLength = gunfire.length;
    }



    // Update is called once per frame
    void Update()
    {
        hasInfiniteAmmo = infiniteAmmoPerk.hasInfiniteAmmo;
        waveNum = zombieSpawner.waveNumber;
        checkCurrentWeapon();


        // If player presses left mouse button fire a bullet
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LaunchProjectile();
        }

        // Ammo UI text
        if(ammo <= 0)
        {
            ammoUI.text = "Bullets: " + 0;
        }
        else
        {
            ammoUI.text = "Bullets: " + ammo;
        }
        
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
            if(!hasInfiniteAmmo)
                ammo--;

            var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            //Physics.IgnoreCollision(projectileInstance.GetComponent<Collider>(), firePoint.parent.GetComponent<Collider>());

            //projectileInstance.AddForce(firePoint.forward * .5f, ForceMode.Impulse);

            projectileInstance.AddForce(firePoint.forward * bulletSpeed);
            
            gunAudio.PlayOneShot(gunfire, 0.2f);

            StartCoroutine(ShootCooldownRoutine());

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
