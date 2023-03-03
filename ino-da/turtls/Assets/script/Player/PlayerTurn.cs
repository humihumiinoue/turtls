using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public float count;        //左右反転カウント
    private float Change = 0.25f;         //反転秒
    private float ResetChange = 0.5f;         //反転解除
    private new SpriteRenderer renderer; //キャラの向き

    public bool StartCount = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            renderer.flipX = false;
        }

        if (StartCount)
        {
            count += Time.deltaTime;
        }
        if (count >= Change)
        {
            renderer.flipX = true;
        }
        if (count >= ResetChange)
        {
            count = 0;
        }

    }
}