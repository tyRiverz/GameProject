using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject UpgradeMenuUI;
 
    void Update()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            if(UpgradeMenuUI.active == true)
            {
                Time.timeScale = 1f;
                UpgradeMenuUI.SetActive(false);
            }
            
        }
    }

    public void Okay()
    {
        GameIsPaused = false;
    }
}
