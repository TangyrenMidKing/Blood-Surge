using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public AudioClip impact;
    AudioSource bulletAudio;
    float audioClipLength;
    public int damage = 30;
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
            DestroyBulletRoutine();

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
        
    }
}
