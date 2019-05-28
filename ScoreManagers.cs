using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class ScoreManagers : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public GameObject score_object2 = null;
    Player x = new Player();
    int num = 0;
    // 初期化
    void Start()
    {
    }

    // 更新
    void Update()
    {
        num = x.blocknum;
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        Text score_text2 = score_object2.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "000000";
        score_text.text = "000000";
    }
}

