using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuriedProcessing : MonoBehaviour
{
   void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(transform.root.gameObject);
        }
    }
}
