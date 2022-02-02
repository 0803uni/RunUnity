using UnityEngine;
using UnityEngine.SceneManagement;

public class DataWrite : MonoBehaviour
{
    [SerializeField]
    DataKeep data;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            data.score = 100;

            SceneManager.LoadScene("ResultScene");
        }
    }
}