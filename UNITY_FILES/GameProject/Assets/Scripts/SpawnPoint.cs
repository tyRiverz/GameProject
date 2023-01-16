using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private int waveNumber = 0;
    public int enemiesAmount = 0;
    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
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

            if (waveNumber % 5 == 0)
            {
                SpawnBoss();
            }
            else
            {
                for (int i = 0; i < waveNumber; i++)
                {
                    SpawnEnemy();
                }
            }

        }

    }

    void SpawnEnemy()
    {

        // D��man objesi �retilir
        //GameObject a = Instantiate(enemy) as GameObject;        

        int enemyNumber = Random.Range(0, enemies.Count - 1);
        GameObject a = Instantiate(enemies[enemyNumber]) as GameObject;

        // �retilen d��man�n pozisyonu kameran�n g�rd��� s�n�rlar i�erisinden rastgele bir noktada se�ilir
        a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.y + Random.Range(-height, height), 0);

    }

    void SpawnBoss()
    {
        GameObject a = Instantiate(enemies[3]) as GameObject;

        // �retilen d��man�n pozisyonu kameran�n g�rd��� s�n�rlar i�erisinden rastgele bir noktada se�ilir
        a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.y + Random.Range(-height, height), 0);
    }
}
