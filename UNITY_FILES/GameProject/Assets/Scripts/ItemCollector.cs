using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int ItemGear = 0;
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

            if (lootName.Contains("Gear"))
            {
                ItemGear++;
                sm.countGear += 1f;
            }
            else if (lootName.Contains("Hp"))
            {
                int hp = Random.Range(20, 40);
                p_movement.TakeHp(hp);
                if (sidekick)
                    sidekick.TakeHp(hp);

            }
            else if (lootName.Contains("Shield"))
            {
                FindObjectOfType<SFXManager>().Play("Shield");
                p_movement.ShieldActive = true;
                //Debug.Log("Shield Active mi: " + p_movement.ShieldActive.ToString());
                sidekick.ShieldActive = true;
                //Debug.Log("Player Shield activated");
                //Debug.Log("Sidekick Shield activated");
                p_movement.ShieldCountdown(10);
                if (sidekick)
                    sidekick.ShieldCountdown(10);
            }

            Destroy(collision.gameObject);
        }
    }
}
