using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip zombieNoise;
    AudioSource zombieNoiseAudio;
    float audioClipLength;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        zombieNoiseAudio = GetComponent<AudioSource>();
        zombieNoiseAudio.playOnAwake = false;
        audioClipLength = zombieNoise.length;
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (zombieNoiseAudio.isPlaying == false) // makes sure the audio only plays once instead over itself multiple times
            zombieNoiseAudio.PlayOneShot(zombieNoise, 0.5f);
        StartCoroutine(StartGameSceneRoutine());

        
    }

    // waits until the audio clip is finished playing before it switches scenes
    IEnumerator StartGameSceneRoutine()
    {
        yield return new WaitForSeconds(audioClipLength);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Succesfully Quit Game!");
    }
}
