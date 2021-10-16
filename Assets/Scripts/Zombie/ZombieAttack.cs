using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform player;
    public Transform zombie;
    public NavMeshAgent agent;
    public AudioClip attack;
    AudioSource attackAudio;
    public int playersCurrentHealth;
    public int zombieDamage = 10;
    public float attackRange;
    float attackCooldown = 3f;
    float lastAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
        attackAudio.playOnAwake = false;
        player = GameObject.Find("PlayerCharacter").transform;
        //zombie = GameObject.Find("ZombieObj").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

            if (Vector3.Distance(player.position, zombie.position) <= attackRange)
            {
                agent.isStopped = true;
                
                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if(Time.time - lastAttack > attackCooldown)
                {
                    lastAttack = Time.time; 
                    attacks(zombieDamage);
                }
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }

    // updates player health depending on what kind of zombie attacks
    private void attacks(int damage)
    {
        attackAudio.PlayOneShot(attack, 1.0f);
        playersCurrentHealth -= damage;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
    }
}
