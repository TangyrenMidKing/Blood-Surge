using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform player;
    public NavMeshAgent agent;
    public AudioClip attack;
    public int zombieDamage;
    public float attackRange;
    public float visualRange;
    AudioSource attackAudio;
    Animator animator;
    int playersCurrentHealth;
    float attackCooldown = 3f;
    float lastAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
        attackAudio.playOnAwake = false;
        player = GameObject.Find("PlayerCharacter").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        //zombie = GameObject.Find("ZombieObj").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

            if (Vector3.Distance(player.position, this.transform.position) > attackRange
                && Vector3.Distance(player.position, this.transform.position) <= visualRange)
            {
                // Running
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }
            else if (Vector3.Distance(player.position, this.transform.position) <= attackRange)
            {
                // Stop running and attacking
                animator.SetBool("isRunning", false);
                agent.isStopped = true;

                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if (Time.time - lastAttack > attackCooldown)
                {
                    lastAttack = Time.time;
                    attacks(zombieDamage);
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
                agent.isStopped = false;
            }
        }
    }

    // updates player health depending on what kind of zombie attacks
    private void attacks(int damage)
    {
        attackAudio.PlayOneShot(attack, 1.0f);
        animator.SetBool("isAttacking", true);
        playersCurrentHealth -= damage;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
    }
}
