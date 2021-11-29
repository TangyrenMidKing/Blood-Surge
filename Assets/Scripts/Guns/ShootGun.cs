using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    public InfiniteAmmoPerk infiniteAmmoPerk;
    public AmmoRefillPerk ammoRefillPerk;
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
    bool hasInfiniteAmmo;
    bool hasAmmoRefill;
    float fireRate;
    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading;

    public Animator animator;



    enum Weapons
    {
        Handgun,
        M4,
        Skorpion,
        Ump,
    }

    // Start is called before the first frame update
    void Start()
    {
        // initialize
        hasInfiniteAmmo = false;
        gunAudio = GetComponent<AudioSource>();
        gunAudio.playOnAwake = false;
        audioClipLength = gunfire.length;

        currentAmmo = maxAmmo;
    }



    // Update is called once per frame
    void Update()
    {
        if((currentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)) && !hasInfiniteAmmo && ammo != 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(isReloading)
        {
            return;
        }

        CheckForAmmoRefill();

        CheckForInfiniteAmmoPerk();

        checkCurrentWeapon();


        // If player presses left mouse button fire a bullet
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LaunchProjectile();
        }

        DisplayAmmoUI();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading....");

        animator.SetBool("reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("reloading", false);

        if (isReloading)
        {
            if (ammo - (maxAmmo - currentAmmo) <= 0)
                ammo = 0;
            else
                ammo -= (maxAmmo - currentAmmo);


            if (ammo < maxAmmo)
                currentAmmo = ammo;
            else
                currentAmmo = maxAmmo;
        }
        isReloading = false;
    }

    void OnEnable ()
    {
        isReloading = false;
        animator.SetBool("reloading", false);
    }



    void CheckForAmmoRefill()
    {
        hasAmmoRefill = ammoRefillPerk.refillAmmo;

        if (hasAmmoRefill)
            ammo = 300;
    }

    void CheckForInfiniteAmmoPerk()
    {
        hasInfiniteAmmo = infiniteAmmoPerk.hasInfiniteAmmo;
        if (hasInfiniteAmmo)
            currentAmmo = maxAmmo;
    }

    // after checking the weapon then assign bulletSpeed
    void checkCurrentWeapon()
    {
        currentWeapon = grabWeapon.GetComponent<GrabWeapon>().getCurrentWeapon(); // gets the index of the weapon in the weaponList array
        switch (currentWeapon)
        {
            case (int)Weapons.Handgun:
                bulletSpeed = 1500f;
                fireRate = 1f;
                break;

            case (int)Weapons.M4:
                bulletSpeed = 2000f;
                fireRate = .5f;
                break;

            case (int)Weapons.Skorpion:
                bulletSpeed = 3500f;
                fireRate = .3f;
                break;

            case (int)Weapons.Ump:
                bulletSpeed = 3000f;
                fireRate = .7f;
                break;

            default:
                bulletSpeed = 1000f;
                break;
        }
    }

    void LaunchProjectile()
    {
        if (shoot && (ammo != 0 || hasInfiniteAmmo))
        {
            DecrementBulletCount();

            FireBullet();
        }
    }
    void DecrementBulletCount()
    {
        // decrement bullet count
        if (!hasInfiniteAmmo)   
            currentAmmo--;
    }

    // Spawns a bullet at the tip of the gun and adds a force to it
    // Calls a coroutine to delay between shots
    void FireBullet()
    {
        var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //Physics.IgnoreCollision(projectileInstance.GetComponent<Collider>(), firePoint.parent.GetComponent<Collider>());

        //projectileInstance.AddForce(firePoint.forward * .5f, ForceMode.Impulse);

        projectileInstance.AddForce(firePoint.forward * bulletSpeed);

        gunAudio.PlayOneShot(gunfire, 0.2f);

        Destroy(projectileInstance.gameObject, 1.045f);

        StartCoroutine(ShootCooldownRoutine(fireRate));

        //Destroy(projectilePrefab, audioClipLength);
        //currentAmmo --;
    }

    // delays time between shots to not have a continous barrage of bullets
    IEnumerator ShootCooldownRoutine(float delay)
    {
        shoot = false;
        yield return new WaitForSeconds(delay);
        shoot = true;
    }

    void DisplayAmmoUI()
    {
        // Ammo UI text
        if (ammo <= 0 && !hasInfiniteAmmo)
        {
            if(currentAmmo <= 0)
                ammoUI.text = "Bullets: " + 0 + "/" + 0;
            else
                ammoUI.text = "Bullets: " + currentAmmo + "/" + 0;
        }
        else if(hasInfiniteAmmo)
        {
            ammoUI.text = "Bullets: \u221E";
        }
        else
        {
            ammoUI.text = "Bullets: " + currentAmmo + "/"+ ammo;
        }
        if (isReloading == true)
        {
            ammoUI.text = "Reloading!";
        }
    }



}