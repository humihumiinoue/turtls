using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator1 : MonoBehaviour
{
    public GameObject[] PrefabWall;
    public bool Generation = true;

    private int number; //ランダム用
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        number = Random.Range(0, PrefabWall.Length);
        Vector3 pos = new Vector3(114.5f, -1.2f, 0.0f);
        //敵を生成
        if (Generation)
        {
            Instantiate(PrefabWall[number], pos, Quaternion.identity);
            Generation = false;
        }
    }
}
