using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    public Canvas pauseUI;
    //public GameObject crosshair;
    public GameOver gameOver;
    int scoreNum;


    /*private void Start()
    {
        pauseUI.enabled = false;
    }*/

    // Update is called once per frame
    void Update()
    {
        scoreNum = gameOver.scoreNum;

        EnablePauseMenu();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // checks if the game is already paused, if so then unpause the game
            if (paused)
            {
                ResumeGame();
                
            }
            else
            {
                PauseGame();
                
            }
        }

    }

    void EnablePauseMenu()
    {
        if (paused)
        {
            pauseUI.enabled = true;
            //crosshair.SetActive(false);
        }
        else
        {
            pauseUI.enabled = false;
            //crosshair.SetActive(true);
        }
    }

    public void ResumeGame()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        paused = false;

    }

    // unlock mouse cursor as well?
    void PauseGame()
    {

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        paused = true;

    }

    public void MainMenu()
    {
        paused = false;
        Time.timeScale = 1f;

        if (scoreNum > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", scoreNum);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
