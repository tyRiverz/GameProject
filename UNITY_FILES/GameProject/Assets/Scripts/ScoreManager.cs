using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public TMP_Text item1Score;
    public TMP_Text item2Score;
    public float score;
    public float countitem1;
    public float countitem2;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        textScore.text = "SCORE: " + score.ToString();
        countitem1 = 0f;
        item1Score.text = "ITEM 1: " + countitem1.ToString();
        countitem2 = 0f;
        item2Score.text = "ITEM 2: " + countitem2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "SCORE: " + score.ToString();
        item1Score.text = "ITEM 1: " + countitem1.ToString();
        item2Score.text = "ITEM 2: " + countitem2.ToString();
    }
}
