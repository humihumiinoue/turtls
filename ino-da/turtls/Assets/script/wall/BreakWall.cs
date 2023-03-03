using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public playercontroller playercontroller;
    public float PSpeed= 0;
    private float BreakSpeed = 0.5f;
    void Update()
    {
        PSpeed = playercontroller.speed;
    }
    private void OnCollisionEnter2D(Collision2D col)// �����蔻��
    {
        if (col.gameObject.tag == "Player")
        {
            if (PSpeed >= BreakSpeed)
            {
                Destroy(transform.root.gameObject);
            }
        }
    }
}
