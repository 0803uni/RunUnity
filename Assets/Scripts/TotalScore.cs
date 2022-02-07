using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField]
    DataKeep data;
    public Text ScoreText;
    int score;
    void Start()
    {
        score = data.score;
        ScoreText.text = string.Format("Score;{0}",score*100);
    }

    
    void Update()
    {

    }
}
