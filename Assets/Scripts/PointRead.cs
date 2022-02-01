using UnityEngine;

public class PointRead : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数

    [SerializeField]
    DataKeep PointData;

    void Start()
    {
        //Debug.Log(data.score);
        score_object = GameObject.Find("Text");
    }
    void Update()
    {
        /* オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Score:" + score_num.ToString();

        score_num += 1; // とりあえず1加算し続けてみる*/
    }
}

