using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private int waveNumber = 0;
    public int enemiesAmount = 0;
    public GameObject enemy;
    public Camera cam;
    float height = 0f;
    float width = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Kamera objesi oluþturulur
        cam = Camera.main;
        enemiesAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // Kameranýn gördüðü sýnýrlar belirlenir
        height = cam.orthographicSize + 1;
        width = cam.orthographicSize * cam.aspect + 1;

        //Sahnedeki düþman sayýsý belirlenir, düþman yoksa yeni dalga baþlatýlýr
        //Her dalgada üretilecek düþman sayýsý artýrýlýr
        enemiesAmount = FindObjectsOfType<Enemy>().Length;

        if (enemiesAmount == 0)
        {
            waveNumber++;
            for (int i = 0; i < waveNumber; i++)
            {
                
                SpawnEnemy();
                
            }
        }
        
    }

    void SpawnEnemy()
    {
        // Düþman objesi üretilir
        GameObject a = Instantiate(enemy) as GameObject;
        // Üretilen düþmanýn pozisyonu kameranýn gördüðü sýnýrlar içerisinden rastgele bir noktada seçilir
        a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width, width), 3, cam.transform.position.z + height + Random.Range(10, 30));        
    }
}
