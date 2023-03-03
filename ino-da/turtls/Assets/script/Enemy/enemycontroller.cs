using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    public float powerEnemy = 1;
    private float speed = 0.05f;

    bool turn = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*Vector2 position = transform.position;
        Time_Eemy += Time.deltaTime;
        if (Time_Eemy < Up)
        {
            position.y += speed;
        }
        if (Time_Eemy > Down)
        {
            position.y -= speed;
        }
        if (Time_Eemy > Reset) 
        {
            Time_Eemy = 0;
        }
        transform.position = position;*/

        
        if (turn)
        {
            transform.Translate(new Vector3(0, speed, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, -speed, 0));
        }   
    }

    private void OnCollisionEnter2D(Collision2D col)// �����蔻��
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        
        if (col.gameObject.tag == "wall")
        {
            if (turn)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }
        }
        if (col.gameObject.tag == "UpDownWall")
        {
            if (turn)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }
        }

    }
    /*public void OnTriggerEnter2D(Collider2D other) //�g���K�[�������蔻��
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(transform.root.gameObject);
            Hp -= other.gameObject.GetComponent<playercontroller>().power;
        }
        if (Hp <= 0)
        {
            Destroy(transform.root.gameObject);

        }
    }*/
}
