using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class TitleButton : MonoBehaviour
{

    void Start()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("TitleScene");
        });
    }



}
