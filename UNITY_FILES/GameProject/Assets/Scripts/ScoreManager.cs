using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text ItemScore;
    public TMP_Text ItemGearScore;
    //public TMP_Text item2Score;
    public float score;
    public float countGear;
    //public float countitem2;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        ItemScore.text = "SCORE: " + score.ToString();
        countGear = 0f;
        ItemGearScore.text = "GEAR: " + countGear.ToString();
        //countitem2 = 0f;
        //item2Score.text = "ITEM 2: " + countitem2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ItemScore.text = "SCORE: " + score.ToString();
        ItemGearScore.text = "GEAR: " + countGear.ToString();
        //item2Score.text = "ITEM 2: " + countitem2.ToString();
    }
}
