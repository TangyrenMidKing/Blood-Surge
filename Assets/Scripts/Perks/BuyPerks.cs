using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPerks : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerHealth playerBaseHealth;
    public GameOver gameOver;
    public ZombieSpawner zombieSpawner;
    public int waveNum;
    public int scoreNum;
    public bool inRangeOfPerks;
    public Text BuyPerkUI;
    public int healScore; // if you change these values rememeber to change them below in the if statement as well
    public int ammoScore;
    public bool refillAmmo;
    int playersCurrentHealth;
    int baseHealth;
    int lastWaveNum;
    // Start is called before the first frame update
    void Start()
    {
        BuyPerkUI.GetComponent<Text>().enabled = false;
        baseHealth = playerHealth.GetComponent<PlayerHealth>().getBaseHealth();
        refillAmmo = false;
        inRangeOfPerks = false;
    }

    // Update is called once per frame
    void Update()
    {
        playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();
        lastWaveNum = waveNum;
        waveNum = zombieSpawner.waveNumber;
        scoreNum = gameOver.scoreNum;

        UpdateBuyPerkScoreRequirements();


        if (Input.GetKeyDown(KeyCode.E) && inRangeOfPerks)
            BuyPerk();
    }

    // update buy health and ammo perk score requirements
    void UpdateBuyPerkScoreRequirements()
    {
        if (waveNum == 1)
        {
            healScore = scoreNum / 3;
            ammoScore = scoreNum / 4;
        }
        else if (lastWaveNum != waveNum)
        {
            healScore = (scoreNum / 3) * 2;
            ammoScore = (scoreNum / 5) * 2;
        }
        else if (waveNum == 0)
        {
            healScore = 0;
            ammoScore = 0;
        }
    }

    void BuyPerk()
    {

        switch (gameObject.tag)
        {
            case "HealthHealWall":
                BuyPerkUI.text = "Spend " + healScore + " score points to heal yourself to full health?";

                if(scoreNum >= healScore && playersCurrentHealth<100)
                {
                    int healthHeal = 50;
                    playersCurrentHealth += healthHeal;
                    if (playersCurrentHealth > 100)
                    {
                        playersCurrentHealth -= playersCurrentHealth % baseHealth; // this line caps the health gained at base health (100)
                    }
                    playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
                    gameOver.setScoreNum(-healScore);

                }

                break;

            case "ammowall":
                
                if(scoreNum>= ammoScore)
                {
                    refillAmmo = true;
                    //scoreNum -= ammoScore;
                    gameOver.setScoreNum(-ammoScore);
                    StartCoroutine(RefillAmmoCountDownRoutine());
                }
                break;

            default:
                break;
        }
    }

    IEnumerator RefillAmmoCountDownRoutine()
    {
        yield return null;
        refillAmmo = false;
    }

    void displayingInstructionsUI()
    {

        BuyPerkUI.GetComponent<Text>().enabled = true;
        switch (gameObject.tag)
        {
            case "HealthHealWall":
                BuyPerkUI.text = "Spend " + healScore + " score points to heal yourself to full health?";


                break;

            case "ammowall":
                BuyPerkUI.text = "Spend " + ammoScore + " score points to refill this gun's ammo?";
                break;

            default:
                break;
        }
    }

    void stopDisplayingInstructionsUI()
    {
        BuyPerkUI.GetComponent<Text>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayingInstructionsUI();
            inRangeOfPerks = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            stopDisplayingInstructionsUI();
            inRangeOfPerks = false;
        }
    }
}
