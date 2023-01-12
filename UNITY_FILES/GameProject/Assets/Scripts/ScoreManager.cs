using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text ItemScore;
    public TMP_Text ItemGearScore;
    public float score;
    public float countGear;    
    
    void Start()
    {
        score = 0f;
        ItemScore.text = "SCORE: " + score.ToString();
        countGear = 0f;
        ItemGearScore.text = "GEAR: " + countGear.ToString();
        
    }
   
    void Update()
    {
        ItemScore.text = "SCORE: " + score.ToString();
        ItemGearScore.text = "GEAR: " + countGear.ToString();
        
    }
}
