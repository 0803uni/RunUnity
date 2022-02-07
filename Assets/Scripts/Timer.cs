using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    DataKeep data;
    public Text timerTexts;
    [SerializeField]
    float totalTime = 15.0f;
    float ritime;
   
    void Start()
    {
        
    }

  
    void Update()
    {
        totalTime -= Time.deltaTime;
        data.score = (int)totalTime  ;
        ritime = totalTime;
        timerTexts.text = ritime.ToString();
        if(ritime==0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
