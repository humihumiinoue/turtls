using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public int Score = 0;   //Score変数
    public GameObject Score_Object = null;  //Scoreテキスト

    // Start is called before the first frame update
    void Start()
    {
        Score = playercontroller.Point; //○○.変数でほかのスクリプト参照
    }

    // Update is called once per frame
    void Update()
    {
        Text Score_Text = Score_Object.GetComponent<Text>();

        Score_Text.text = "Score:" + Score;
    }
}
