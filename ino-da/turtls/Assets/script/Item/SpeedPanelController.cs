using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPanelController : MonoBehaviour
{
    public GameObject[] PrefabSpeedPanel;
    public bool SpeedLoop = true;

    private int repetition = 0; //ループ停止用

    private int number; //ランダム用

    [SerializeField]
    private int PanelAmount = 10;    //スピードパネル生成個数
    private float x1 = 39.0f, x2 = 340.0f;
    private float y1 = 11.0f, y2 = 14.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        while (SpeedLoop)
        {
            repetition+=1;
            number = Random.Range(0, PrefabSpeedPanel.Length);
            float x = Random.Range(x1, x2);
            float y = Random.Range(y1, -y2);
            Vector3 pos = new Vector3(x, y, 0.0f);
            //敵を生成
            if (!Physics.CheckBox(pos, transform.position, Quaternion.identity, 1 << 12))
            {
                Instantiate(PrefabSpeedPanel[number], pos, Quaternion.identity);
            }
            if (repetition >= PanelAmount)
            {
                SpeedLoop = false;
            }
        }
    }
}
