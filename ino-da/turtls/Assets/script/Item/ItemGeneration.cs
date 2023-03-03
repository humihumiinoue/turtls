using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    public GameObject[] PrefabItem;
    public bool ItemLoop = true;


    public warp warp;

    bool count = true;

    private int repetition = 0; //ループ用int

    private int number; //ランダム用
    [SerializeField]
    private int ItemAmount = 5; //アイテム生成個数

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

        if (count && warp.warp_count % 3 == 0)
        {
            ItemLoop = true;
        }
        count = false;

        while (ItemLoop)
        {
            repetition+=1;
            number = Random.Range(0, PrefabItem.Length);
            float x = Random.Range(x1, x2);
            float y = Random.Range(y1, -y2);
            Vector3 pos = new Vector3(x, y, 0.0f);
            //敵を生成
            if (!Physics.CheckBox(pos, transform.position, Quaternion.identity, 1 << 12))
            {
                Instantiate(PrefabItem[number], pos, Quaternion.identity);
            }
            if (repetition >= ItemAmount)
            {
                ItemLoop = false;
                repetition = 0;
            }
        }
    }
}
