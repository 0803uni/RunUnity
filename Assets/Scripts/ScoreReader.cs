using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour
{
    [SerializeField]
    //DetaKeep Scoredata;
    //[SerializeField]
    GameObject scoreTextObject;
    //[SerializeField]
    Text scoreText;

    private void Awake()
    {
        //  var a = GameObject.Find("ScoreText");
        //   scoreTextObject = GameObject.Find("ScoreText");
        scoreText = GetComponent<Text>();
    }
    void Start()
    {

        // scoreText.text = "SCORE"+ Scoredata.score.ToString("F2");
       // scoreText.text = "SCORE:" + String.Format($"{Math.Ceiling(Scoredata.score * 100)}");

    }


    void Update()
    {

    }
}
