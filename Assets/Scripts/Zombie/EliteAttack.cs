using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
    shooting range > visual range > attacking range
*/

public class EliteAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform player;
    public NavMeshAgent agent;
    public AudioClip attack;
    public int zombieDamage;
    public int shootDamage;
    public float shootRange;
    public float attackRange;
    AudioSource attackAudio;
    Animator animator;
    int playersCurrentHealth;
    float attackCooldown = 3f;
    float shootCooldown = 4f;
    float lastAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
        attackAudio.playOnAwake = false;
        player = GameObject.Find("PlayerCharacter").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {

        // Elite Zombie
        if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();


            // shoot range --> current position --> attack range
            // Shooting and Running
            if (Vector3.Distance(player.position, this.transform.position) > attackRange
                    && Vector3.Distance(player.position, this.transform.position) <= shootRange)
            {
                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if (Time.time - lastAttack > shootCooldown)
                {
                    // Stop running and attacking
                    agent.isStopped = false;

                    lastAttack = Time.time;
                    animator.SetBool("isShooting", true);
                    animator.SetBool("isAttacking", false);
                    attacks(shootDamage);
                }
            }

            // attack range --> current position  
            // stop and attacking 
            else if (Vector3.Distance(player.position, this.transform.position) < attackRange)
            {
                // Stop running and attacking
                agent.isStopped = true;

                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if (Time.time - lastAttack > attackCooldown)
                {
                    lastAttack = Time.time;
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isShooting", false);
                    attackAudio.PlayOneShot(attack, 1.0f);
                    attacks(zombieDamage);
                }
            }

            // current position > visual range
            // only walk
            else
            {
                animator.SetBool("isShooting", false);
                animator.SetBool("isAttacking", false);
                agent.isStopped = false;
            }
        }
    }

    // updates player health depending on what kind of zombie attacks
    private void attacks(int damage)
    {
        playersCurrentHealth -= damage;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
    }
}
