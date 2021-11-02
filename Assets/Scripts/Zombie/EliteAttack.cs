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
    public float visualRange;
    AudioSource attackAudio;
    Animator animator;
    int playersCurrentHealth;
    float attackCooldown = 3f;
    float shootCooldown = 4f;
    float lastAttack = 0f;

    /*  states:
            0 -> walking
            1 -> running
            2 -> shooting
            3 -> attacking
            4 -> dead
    */
    int state;

    // Start is called before the first frame update
    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
        attackAudio.playOnAwake = false;
        player = GameObject.Find("PlayerCharacter").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // Elite Zombie
        if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

            // visual range >= current position > shoot range
            // Running 
            if (Vector3.Distance(player.position, this.transform.position) > shootRange
                && Vector3.Distance(player.position, this.transform.position) <= visualRange)
            {
                // walking -> running
                if (state == 0)
                    ;
                // shoot -> running
                else if (state == 2)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isShooting", false);
                }
                // attack -> running
                else if (state == 3)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isAttacking", false);
                }

                animator.SetBool("isRunning", true);
                state = 1;
            }

            // shoot range >= current position > attack range
            // Shooting and Running
            else if (Vector3.Distance(player.position, this.transform.position) > attackRange
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
                    state = 2;
                    attacks(shootDamage);
                }
            }

            // current position < attack range
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
                    state = 3;
                    attacks(zombieDamage);
                }
            }

            // current position > visual range
            // only walk
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isShooting", false);
                animator.SetBool("isAttacking", false);
                state = 0;
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
