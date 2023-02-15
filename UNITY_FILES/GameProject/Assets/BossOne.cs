using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOne : MonoBehaviour
{
    public GameObject deathEffect;
    private ScoreManager sm;

    public HealthBar healthBar;
    public int maxHealth = 500;
    public int currentHealth;

    private UpgradeMenu um;


    private int waveNumber = 0;
    public int enemiesAmount = 0;
    private int enemiesToSpawn = 0;
    private int enemyConstant = 3;    
    public List<GameObject> enemies = new List<GameObject>();    


    public void Start()
    {        
        enemiesAmount = 0;
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

    void SpawnEnemy()
    {

        // Düþman objesi üretilir
        //GameObject a = Instantiate(enemy) as GameObject;        
        
        GameObject a = Instantiate(enemies[0]) as GameObject;

        // Üretilen düþmanýn pozisyonu kameranýn gördüðü sýnýrlar içerisinden rastgele bir noktada seçilir
        a.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y , 0);

    }

    void Update()
    {        

        if(currentHealth <= 400)
        {
            for(int i = 0; i < 5; i++)
            {
                SpawnEnemy();
            }
        }
        else if (currentHealth <= 200)
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnEnemy();
            }
        }
    }
}
