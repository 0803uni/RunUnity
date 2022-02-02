using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI処理のクラスを使用する宣言
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    // Image コンポーネントを格納する変数
    private Image m_Image;
    // スプライトオブジェクトを格納する配列
    public Sprite[] m_Sprite;
    // スプライトオブジェクトを変更するためのフラグ
    bool Change;

    // ゲーム開始時に実行する処理
    void Start()
    {
        // スプライトオブジェクトを変更するためのフラグを false に設定
        Change = false;
        // Image コンポーネントを取得して変数 m_Image に格納
        m_Image = GetComponent<Image>();
    }

    // ゲーム実行中に毎フレーム実行する処理
    void Update()
    {
        // スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スプライトオブジェクトの変更フラグが true の場合
            if (Change)
            {
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[0] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[0];
                Change = false;
            }
            // スプライトオブジェクトの変更フラグが false の場合
            else
            {
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[1] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[1];
                Change = true;
            }
        }
    }
}