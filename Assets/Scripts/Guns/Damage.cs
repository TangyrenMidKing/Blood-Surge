using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public AudioClip impact;
    public ShootGun shootGun;
    public GrabWeapon grabWeapon;
    AudioSource bulletAudio;
    float audioClipLength;
    public int damage;
    int currentWeapon;
    

    enum Weapons
    {
        Handgun,
        M4,
        Skorpion,
        Ump,
        Minigun
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
        bulletAudio.playOnAwake = false;
        audioClipLength = impact.length;
    }

    void OnCollisionEnter(Collision other)
    {
        
        Target target = other.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.Hit(damage);
            playImpactAudio();
            StartCoroutine(DestroyBulletRoutine());
        }
    }

    // to give enough time to play the full length of the audio clip
    // this will delay destroying the bullet object until the audio clip is complete
    IEnumerator DestroyBulletRoutine()
    {
        yield return new WaitForSeconds(audioClipLength);

        Destroy(gameObject);
    }

    void playImpactAudio()
    {
        bulletAudio.PlayOneShot(impact, 0.5f);
    }

    // // Update is called once per frame
    void Update()
    {

        // check current weapon to determine how much damage
        currentWeapon = grabWeapon.GetComponent<GrabWeapon>().getCurrentWeapon(); // gets the index of the weapon in the weaponList array

        switch (currentWeapon)
        {
            case (int)Weapons.Handgun:
                damage = 20;
                break;

            case (int)Weapons.M4:
                damage = 35;
                break;

            case (int)Weapons.Skorpion:
                damage = 50;
                break;

            case (int)Weapons.Ump:
                damage = 55;
                break;

            case (int)Weapons.Minigun:
                damage = 30;
                break;

            default:
                damage = 100;
                break;
        }
    }

}
