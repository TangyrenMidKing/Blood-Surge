using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public AudioClip death;
    AudioSource deathAudio;
    float audioClipLength;
    // Start is called before the first frame update
    void Start()
    {
        deathAudio = GetComponent<AudioSource>();
        deathAudio.playOnAwake = false;
        audioClipLength = death.length;
    }

    // Update is called once per frame
    void Update()
    {
        RestartLevel();

        
    }

    // If players current health is below or equal to zero then reset level
    void RestartLevel()
    {
        if (playerHealth.GetComponent<PlayerHealth>().getHealth() <= 0)
        {
            if (deathAudio.isPlaying == false)
                deathAudio.PlayOneShot(death, 0.5f);
            StartCoroutine(RestartScene());

            
        }
    }

    // waits for the audio clip to finish playing before switching scenes
    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(audioClipLength);

        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
