using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPoint : MonoBehaviour
{
    private int waveNumber = 0;
    public int enemiesAmount = 0;
    private int enemiesToSpawn = 0;
    private int enemyConstant = 3;
    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public Camera cam;
    float height = 0f;
    float width = 0f;

    public Tilemap tilemap = null;
    List<Vector3> availablePlaces;    

    // Start is called before the first frame update
    void Start()
    {
        // Kamera objesi olu�turulur
        cam = Camera.main;
        enemiesAmount = 0;
        // Kameran�n g�rd��� s�n�rlar belirlenir
        height = cam.orthographicSize + 1;
        width = cam.orthographicSize * cam.aspect + 1;

        
        availablePlaces = new List<Vector3>();

        for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
        {
            for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)tilemap.transform.position.y);
                Vector3 place = tilemap.CellToWorld(localPlace);
                if (tilemap.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlaces.Add(place);
                }
                else
                {
                    //No tile at "place"
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Sahnedeki d��man say�s� belirlenir, d��man yoksa yeni dalga ba�lat�l�r
        //Her dalgada �retilecek d��man say�s� art�r�l�r
        enemiesAmount = FindObjectsOfType<Enemy>().Length;

        if (enemiesAmount == 0)
        {
            waveNumber++;
            enemiesToSpawn = enemyConstant * waveNumber;

            if (waveNumber % 5 == 0)
            {
                SpawnBoss();
            }
            else
            {
                for (int i = 0; i < enemiesToSpawn; i++)
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
        //a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.y + Random.Range(-height, height), 0);

        int division = Random.Range(0, availablePlaces.Count);

        a.transform.position = availablePlaces[division];


        //int division = Random.Range(0, 4);

        //if (division == 0)
        //{
        //    a.transform.position = new Vector3(cam.transform.position.x + width, cam.transform.position.y + Random.Range(0, height), 0);
        //}
        //else if(division == 1)
        //{
        //    a.transform.position = new Vector3(cam.transform.position.x + Random.Range(0, width), cam.transform.position.y + height, 0);
        //}
        //else if(division == 2)
        //{
        //    a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width,0), cam.transform.position.y - height, 0);
        //}
        //else if(division == 3)
        //{
        //    a.transform.position = new Vector3(cam.transform.position.x - width, cam.transform.position.y + Random.Range(-height,0), 0);
        //}
    }

    void SpawnBoss()
    {
        GameObject a = Instantiate(enemies[3]) as GameObject;

        // �retilen d��man�n pozisyonu kameran�n g�rd��� s�n�rlar i�erisinden rastgele bir noktada se�ilir
        //a.transform.position = new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.y + Random.Range(-height, height), 0);

        int division = Random.Range(0, availablePlaces.Count);

        a.transform.position = availablePlaces[division];
    }


}
