using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBonusWall : MonoBehaviour
{
    private float BreakSpeed = 0.45f;
    [SerializeField]
    private float PlayerSpeed = 0;
    public playercontroller playercontroller;


    void Update()
    {
        PlayerSpeed = playercontroller.speed;
    }
    private void OnCollisionEnter2D(Collision2D col)// �����蔻��
    {
        if (col.gameObject.tag == "BreakWall")
        {
            if (PlayerSpeed >= BreakSpeed)
            {
                Destroy(col. gameObject);
            }
        }
    }
}
