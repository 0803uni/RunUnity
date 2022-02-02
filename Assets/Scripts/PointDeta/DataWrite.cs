using UnityEngine;
using UnityEngine.SceneManagement;

public class DataWrite : MonoBehaviour
{
    [SerializeField]
    DataKeep data;
    private float totalTime;
    private object timerTexts;
    private int retime;

    void Update()
    {
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;
        timerTexts = retime.ToString();

        if (retime == 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.score = 100;

            SceneManager.LoadScene("ResultScene");
        }
    }
}