using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
   public void OnTriggerEnter2D(Collider2D other)// �����蔻��
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
