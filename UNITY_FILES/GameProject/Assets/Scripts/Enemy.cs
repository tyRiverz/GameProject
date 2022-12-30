using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        // Düþman hasar alýr caný biterse ölür
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }
}
