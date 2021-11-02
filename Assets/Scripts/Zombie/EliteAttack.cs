using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    float lastAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
        attackAudio.playOnAwake = false;
        player = GameObject.Find("PlayerCharacter").transform;
        animator = GetComponent<Animator>();
        setAnimationStates("walking");
    }

    // Update is called once per frame
    void Update()
    {
        // basic zombie
        if (player && shootRange <= 0)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

            if (Vector3.Distance(player.position, this.transform.position) > attackRange
                && Vector3.Distance(player.position, this.transform.position) <= visualRange)
            {
                // Running
                setAnimationStates("running");
            }
            else if (Vector3.Distance(player.position, this.transform.position) <= attackRange)
            {
                // Stop running and attacking
                agent.isStopped = true;

                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if (Time.time - lastAttack > attackCooldown)
                {
                    lastAttack = Time.time;
                    setAnimationStates("attacking");
                    attacks(zombieDamage);
                }
            }
            else
            {
                setAnimationStates("walking");
                agent.isStopped = false;
            }
        }
        // Elite Zombie
        else if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();

            if (Vector3.Distance(player.position, this.transform.position) > shootRange
                && Vector3.Distance(player.position, this.transform.position) <= visualRange)
            {
                // Running
                setAnimationStates("running");
            }
            else if (Vector3.Distance(player.position, this.transform.position) > attackRange
                    && Vector3.Distance(player.position, this.transform.position) <= shootRange)
            {
                // Stop running and attacking
                agent.isStopped = true;

                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if (Time.time - lastAttack > attackCooldown)
                {
                    lastAttack = Time.time;
                    setAnimationStates("shooting");
                    attacks(shootDamage);
                }
            }
            else if (Vector3.Distance(player.position, this.transform.position) < attackRange)
            {
                // Stop running and attacking
                agent.isStopped = true;

                // if the time since the zombie last attacked is greater than the attack cooldown then it can attack again
                if (Time.time - lastAttack > attackCooldown)
                {
                    lastAttack = Time.time;
                    setAnimationStates("attacking");
                    attacks(zombieDamage);
                }
            }
            else
            {
                setAnimationStates("walking");
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

    private void setAnimationStates(string state)
    {
        if (state.Equals("walking"))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", true);
        }
        else if (state.Equals("running"))
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
        }
        else if (state.Equals("attacking"))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
        else if (state.Equals("shooting"))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isShooting", true);
        }
        else if (state.Equals("dead"))
        {
            animator.SetBool("isDead", true);
        }
    }
}
