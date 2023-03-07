using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject UpgradeMenuUI;
    private int PowerLevel = 1;
    private int SpeedLevel = 1;
    public static int TypeLevel = 1;

    private int maxPowerLevel = 3;
    private int maxSpeedLevel = 3;
    private int maxTypeLevel = 3;

    public static bool PowerMaxed = false;
    public static bool SpeedMaxed = false;
    public static bool TypeMaxed = false;

    public GameObject PowerButton;
    public GameObject SpeedButton;
    public GameObject TypeButton;
    public GameObject OKButton;

    void Start()
    {        
        OKButton.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            if (UpgradeMenuUI.activeInHierarchy == true)
            {
                Time.timeScale = 1f;
                UpgradeMenuUI.SetActive(false);
            }

        }
    }

    public void Okay()
    {
        if (PowerMaxed == false)
        {
            PowerButton.GetComponent<Button>().interactable = true;
        }
        if (SpeedMaxed == false)
        {
            SpeedButton.GetComponent<Button>().interactable = true;
        }
        if (TypeMaxed == false)
        {
            TypeButton.GetComponent<Button>().interactable = true;
        }
        OKButton.GetComponent<Button>().interactable = false;
        GameIsPaused = false;
    }

    public void UpgradePower()
    {
        if (PowerLevel != maxPowerLevel)
        {
            FindObjectOfType<SFXManager>().Play("Upgrade");

            Bullet.damage += 10;
            TextMeshProUGUI[] components = GameObject.Find("UpgradePowerButton").GetComponentsInChildren<TextMeshProUGUI>(true);
            PowerLevel++;
            if (PowerLevel != maxPowerLevel)
            {
                components[1].text = "LV." + PowerLevel.ToString();
                PowerButton.GetComponent<Button>().interactable = false;
                SpeedButton.GetComponent<Button>().interactable = false;
                TypeButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                components[1].text = "MAX";
                PowerMaxed = true;
                PowerButton.GetComponent<Button>().interactable = false;
                SpeedButton.GetComponent<Button>().interactable = false;
                TypeButton.GetComponent<Button>().interactable = false;
            }
            OKButton.GetComponent<Button>().interactable = true;
        }

    }

    public void UpgradeSpeed()
    {
        if (SpeedLevel != maxSpeedLevel)
        {
            FindObjectOfType<SFXManager>().Play("Upgrade");

            Shooting.fireDelay -= 100;
            TextMeshProUGUI[] components = GameObject.Find("UpgradeSpeedButton").GetComponentsInChildren<TextMeshProUGUI>(true);
            SpeedLevel++;
            if (SpeedLevel != maxSpeedLevel)
            {
                components[1].text = "LV." + SpeedLevel.ToString();
                PowerButton.GetComponent<Button>().interactable = false;
                SpeedButton.GetComponent<Button>().interactable = false;
                TypeButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                components[1].text = "MAX";
                SpeedMaxed = true;
                PowerButton.GetComponent<Button>().interactable = false;
                SpeedButton.GetComponent<Button>().interactable = false;
                TypeButton.GetComponent<Button>().interactable = false;
            }
            OKButton.GetComponent<Button>().interactable = true;
        }
    }

    public void UpgradeType()
    {
        if (TypeLevel != maxTypeLevel)
        {
            FindObjectOfType<SFXManager>().Play("Upgrade");
            TextMeshProUGUI[] components = GameObject.Find("UpgradeTypeButton").GetComponentsInChildren<TextMeshProUGUI>(true);
            TypeLevel++;
            if (TypeLevel != maxTypeLevel)
            {
                components[1].text = "LV." + TypeLevel.ToString();
                PowerButton.GetComponent<Button>().interactable = false;
                SpeedButton.GetComponent<Button>().interactable = false;
                TypeButton.GetComponent<Button>().interactable = false;
                
            }
            else
            {
                components[1].text = "MAX";
                TypeMaxed = true;
                PowerButton.GetComponent<Button>().interactable = false;
                SpeedButton.GetComponent<Button>().interactable = false;
                TypeButton.GetComponent<Button>().interactable = false;
            }
            OKButton.GetComponent<Button>().interactable = true;
        }
    }
}
