using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataRead : MonoBehaviour
{
    [SerializeField]
    DataKeep data;
    [SerializeField]
    GameObject scoreTextObject;
    Text scoreText;

    

    void Start(DataKeep data)
    {
        scoreText.text = "data.score:" + String.Format(format: $"{Math.Abs(data.score * 100)}");
        Debug.Log(data.score);
    }
    private void Awake()
    {
        //  var a = GameObject.Find("ScoreText");
        //   scoreTextObject = GameObject.Find("ScoreText");
       // scoreText = GetComponent<Text>(data.score);
    }
    IEnumerator Wait3Seconds()
    {
        data.score = GetComponent<Text>(data.score);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ResultScene");
    }

    private int GetComponent<T>(int score)
    {
        throw new NotImplementedException();
    }
    //private T GetComponent<T>(int score)
    //{
    //    throw new NotImplementedException();
    //}
}
