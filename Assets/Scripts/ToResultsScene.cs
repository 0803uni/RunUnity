using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ToResultsScene : MonoBehaviour
{
     public Text timerTexts;
    float totalTime = 99;
    int retime;

    [SerializeField]
    DataKeep data;
    //[SerializeField]
    //FightData fightData;
    //[SerializeField]
    //GameObject countdownObject;
    //[SerializeField]
    //CountDown countDown;




    private void Start()
    {
       // countdownObject = GameObject.Find("CountdownText");
       // countDown = countdownObject.GetComponent<CountDown>();


    }
    void Update()
    {
        //totalTime -= Time.deltaTime;
        //retime = (int)totalTime;
        //timerTexts.text = retime.ToString();

        //if (retime == 0)
        //{
        //    SceneManager.LoadScene("ResultScene");
        //}
        //if (fightData.GetBoxHp() <= 0 || fightData.GetKyleHp() <= 0 || countDown.CountDownTime <= 0)
        //{
        //    StartCoroutine(Wait3Seconds());

        //}
    }
    IEnumerator Wait3Seconds()
    {
        // Pointdata.remainingTime = countDown.CountDownTime;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ResultScene");
    }


}
