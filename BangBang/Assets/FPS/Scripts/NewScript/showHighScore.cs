using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHighScore : MonoBehaviour
{
    public Text text;
    public static int score = scoreManager.score;

    private void Awake()
    {

        text = GetComponent<Text>();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        
        text.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();

    }
    public void Update()
    {
        // text.text = "Score : " + end_score.ToString();
    }
}
