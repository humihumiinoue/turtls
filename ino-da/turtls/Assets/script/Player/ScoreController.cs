using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public int Score = 0;   //Score�ϐ�
    public GameObject Score_Object = null;  //Score�e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        Score = playercontroller.Point; //����.�ϐ��łق��̃X�N���v�g�Q��
    }

    // Update is called once per frame
    void Update()
    {
        Text Score_Text = Score_Object.GetComponent<Text>();

        Score_Text.text = "Score:" + Score;
    }
}
