using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppeditemPrefab;
    public List<Loot> lootList = new List<Loot>();    

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();

        // �nceden belirlenen muhtemel toplanabilir objeler s�ras�yla gezilir
        // E�er rastgele olu�turulan say� objenin d��me ihtimalinden k���kse
        // d��ebilecek muhtemel objeler listesine eklenir

        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }


        // E�er listeye objeler eklenmi�se objeler aras�nda rastgele se�im yap�l�r, obje d�n�l�r

        if(possibleItems.Count > 0) 
        {
            Loot droppedItem = possibleItems[Random.Range(0,possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("no item dropped");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPoint)
    {
        Loot droppedItem = GetDroppedItem();

        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppeditemPrefab, spawnPoint, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            droppeditemPrefab.name = droppedItem.lootName;  
            // Belirli s�re i�erisinde loot al�nmazsa yok et
            Destroy(lootGameObject, 10f);


            float dropForce = 30f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }    
}
