using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public GameObject deathEffect;
    private ScoreManager sm;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        sm = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }
    public void TakeDamage(int damage)
    {
        // D��man hasar al�r can� biterse �l�r
        currentHealth -= damage;
        healthBar.SetHealth(damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        sm.score += 100f;
        Destroy(gameObject);    
    }
}
