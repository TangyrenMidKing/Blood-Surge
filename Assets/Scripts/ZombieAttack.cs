using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform player;
    public int playersCurrentHealth;
    public int zombieDamage;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float attackRange;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("PlayerCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            playersCurrentHealth = playerHealth.GetComponent<PlayerHealth>().getHealth();
        }

        if (Vector3.Distance(transform.position,player.position) <= attackRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            ///Attack code here
            attacks(zombieDamage);
            ///End of attack code
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // updates player health depending on what kind of zombie attacks
    private void attacks(int damage)
    {
        playersCurrentHealth -= damage;
        playerHealth.GetComponent<PlayerHealth>().setHealth(playersCurrentHealth);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
