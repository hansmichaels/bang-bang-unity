using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static int score;

    public Text textA;
    
    private void Awake()
    {
        textA = GetComponent<Text>();
        score = 0;
    }

    private void Update()
    {
        textA.text = "Score : " + score;
    }
}
