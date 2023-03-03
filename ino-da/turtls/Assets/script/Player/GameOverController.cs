using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public bool one1 = false;
    public bool one2 = false;
    private float Move = 0.01f;
    private float MoveCount = 0;
    private float MoveStop = 1.0f;
    void Update()
    {
        if (one1)
        {
            while (MoveCount <= MoveStop)
            {
                MoveCount += Time.deltaTime;
                transform.position = new Vector3(transform.position.x - Move, transform.position.y, 0);
            }
            one1 = false;
        }
        if (one2)
        {
            while (MoveCount <= MoveStop)
            {
                MoveCount += Time.deltaTime;
                transform.position = new Vector3(transform.position.x + Move, transform.position.y, 0);
            }
            one2 = false;
        }

        MoveCount = 0;
    }
    //プレイヤーが触れたらゲームオーバーにする
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                SceneManager.LoadScene("gameovescene");
        }
    }
}
