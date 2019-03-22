using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int EnemyDuriablity;
    public int armorPlus;
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    Animator anim;
    public AudioClip deathClip;
    public AudioClip hurt;
    bool isDead;
    AudioSource enemyAudio;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        enemyAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }




    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;
        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        anim.SetTrigger("TakeDamage");
        enemyAudio.clip = hurt;
        enemyAudio.Play();
   
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }
    void Death()
    {
        // The enemy is dead.
        isDead = true;
        anim.SetTrigger("Death");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }
}
