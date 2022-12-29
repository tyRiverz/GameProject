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
        // Kamera objesi olu�turulur
        cam = Camera.main;
        enemiesAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // Kameran�n g�rd��� s�n�rlar belirlenir
        height = cam.orthographicSize + 1;
        width = cam.orthographicSize * cam.aspect + 1;

        //Sahnedeki d��man say�s� belirlenir, d��man yoksa yeni dalga ba�lat�l�r
        //Her dalgada �retilecek d��man say�s� art�r�l�r
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
        // D��man objesi �retilir
        GameObject a = Instantiate(enemy) as GameObject;
        // �retilen d��man�n pozisyonu kameran�n g�rd��� s�n�rlar i�erisinden rastgele bir noktada se�ilir
        a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width, width), 3, cam.transform.position.z + height + Random.Range(10, 30));        
    }
}
