using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 40;
    //void OnCollisionEnter2D(Collision2D collision)
    //{        
        
    //}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (hitInfo.name != "Player")
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);
            //Destroy(hitEffect); 
            Destroy(gameObject);
        }
                   
    }
}
