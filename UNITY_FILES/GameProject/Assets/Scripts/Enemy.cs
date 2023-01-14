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

    private UpgradeMenu um;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        sm = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }
    public void TakeDamage(int damage)
    {
        // Düþman hasar alýr caný biterse ölür
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

        if (gameObject.name == "EnemyBoss")
        {
            Destroy(gameObject);

            um = GameObject.Find("Canvas").GetComponent<UpgradeMenu>();
            UpgradeMenu.GameIsPaused = true;
            um.UpgradeMenuUI.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
