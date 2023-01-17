using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject DeathMenuUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        //else
        //{
        //    if (DeathMenuUI.activeInHierarchy == true)
        //    {
        //        Time.timeScale = 1f;
        //        SceneManager.LoadScene(0);
        //    }

        //}
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
