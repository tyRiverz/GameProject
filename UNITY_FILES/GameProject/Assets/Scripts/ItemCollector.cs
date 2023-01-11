using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int ItemGear = 0;
    public int ItemHp = 0;
    //public int ItemShield = 0;
    private ScoreManager sm;
    private Player_Movement p_movement;
    private SidekickAI sidekick;

    public void Start()
    {
        sm = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        p_movement = GameObject.Find("Player").GetComponent<Player_Movement>();
        sidekick = GameObject.Find("Sidekick").GetComponent<SidekickAI>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {

            string lootName = collision.gameObject.name;

            if (lootName.Contains("ItemGear"))
            {
                ItemGear++;
                sm.countGear += 1f;
            }
            else if (lootName.Contains("ItemHp"))
            {
                ItemHp++;
                int hp = Random.Range(20, 40);
                p_movement.TakeHp(hp);
                sidekick.TakeHp(hp);
                //item2Count++;
                //sm.countitem2 += 1f;
            }
            else if (lootName.Contains("ItemShield"))
            {
                p_movement.ShieldActive = true;
                sidekick.ShieldActive = true;
                Debug.Log("Player Shield activated");
                Debug.Log("Sidekick Shield activated");
                p_movement.ShieldCountdown(10);
                sidekick.ShieldCountdown(10);
            }

            Destroy(collision.gameObject);
        }
    }
}
