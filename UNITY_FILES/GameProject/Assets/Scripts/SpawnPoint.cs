using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private int waveNumber = 0;
    public int enemiesAmount = 0;
    public GameObject enemy;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        enemiesAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float height = cam.orthographicSize + 1;
        float width = cam.orthographicSize * cam.aspect + 1;

        if (enemiesAmount == 0)
        {
            waveNumber++;
            for (int i = 0; i < waveNumber; i++)
            {
                Instantiate(enemy, new Vector3(cam.transform.position.x + Random.Range(-width, width), 3, cam.transform.position.z+height + Random.Range(10, 30)), Quaternion.identity);
                enemiesAmount++;
            }
        }
    }
}
