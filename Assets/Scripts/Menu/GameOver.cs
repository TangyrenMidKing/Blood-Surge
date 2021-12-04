using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SpawnPerk spawnPerk;
    public ZombieSpawner zombieSpawner;
    public PlayerHealth playerHealth;
    public AudioClip death;
    public Text score;
    AudioSource deathAudio;
    float audioClipLength;
    public int specialEnemiesKilled;
    public int enemiesKilled;
    public int waveNum;
    public int scoreNum;
    int buyPerksScore;
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

        waveNum = zombieSpawner.waveNumber;

        enemiesKilled = spawnPerk.getEnemiesKilled();

        specialEnemiesKilled = spawnPerk.getSpecialEnemiesKilled();

        //scoreNum = (waveNum * (enemiesKilled + (2 * specialEnemiesKilled)));

        score.text = "Score: " + scoreNum;

        RestartLevel();


    }

    public void setScoreNum(int _scoreNum)
    {
        scoreNum +=_scoreNum;
        Debug.Log("Setting Score");
    }

    // If players current health is below or equal to zero then reset level
    void RestartLevel()
    {
        if (playerHealth.GetComponent<PlayerHealth>().getHealth() <= 0)
        {
            if(scoreNum > PlayerPrefs.GetInt("HighScore",0))
                PlayerPrefs.SetInt("HighScore", scoreNum);

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
