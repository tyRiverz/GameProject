using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject deathEffect;
    private SpawnPoint sp; 
    private ScoreManager sm;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    private UpgradeMenu um;

    private bool firstDeploy = false;
    private bool secondDeploy = false;

    //private SpawnPoint sp = new SpawnPoint();
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        sm = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        sp = GameObject.Find("SpawnPoint").GetComponent<SpawnPoint>();
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
        FindObjectOfType<SFXManager>().Play("Explode");

        GetComponent<LootBag>().InstantiateLoot(transform.position);
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        sm.score += 100f;

        //Debug.Log(gameObject.name);

        if (gameObject.name.Contains("EnemyBoss"))
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            um = GameObject.Find("Canvas").GetComponent<UpgradeMenu>();
            if (!(UpgradeMenu.SpeedMaxed && UpgradeMenu.TypeMaxed && UpgradeMenu.PowerMaxed))
            {
                UpgradeMenu.GameIsPaused = true;
                um.UpgradeMenuUI.SetActive(true);
            }
        }
        else
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (gameObject.name.Contains("EnemyBoss"))
        {
            if(currentHealth <= 400)
            {
                if(firstDeploy == false)
                {
                    firstDeploy= true;
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject a = Instantiate(sp.enemies[0]) as GameObject;
                        a.transform.position = gameObject.transform.position + new Vector3(i,0,0);
                    }
                }
                
            }
            if(currentHealth <= 200)
            {
                if(secondDeploy == false)
                {
                    secondDeploy= true;
                    for (int i = 0; i < 5; i++)
                    {
                        GameObject a = Instantiate(sp.enemies[0]) as GameObject;
                        a.transform.position = gameObject.transform.position + new Vector3(i, 0, 0);
                    }
                }
                
            }
        }    
    }
}
