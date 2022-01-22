using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{

    void Start()
    {
        var button = GetComponent<Button>();
        //ボタンを押したときのリスナー設定
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StageScene01");
        });
    }
}
