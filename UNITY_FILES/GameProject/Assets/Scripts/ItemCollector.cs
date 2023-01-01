using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int item1Count = 0;
    public int item2Count = 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {

            string lootName = collision.gameObject.name;
            
            if (lootName.Contains("item1"))
            {
                item1Count++;                

            }
            else if (lootName.Contains("item2"))
            {
                item2Count++;
                
            }

            Destroy(collision.gameObject);
        }
    }
}
