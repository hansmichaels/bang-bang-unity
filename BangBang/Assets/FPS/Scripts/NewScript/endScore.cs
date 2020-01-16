using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScore : MonoBehaviour
{
    public Text text;
    public static int end_score = scoreManager.score;

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "Score : " + end_score.ToString();
        
    }
    public void Update()
    {
        // text.text = "Score : " + end_score.ToString();
    }
}
