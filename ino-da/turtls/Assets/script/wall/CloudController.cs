using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour

{
    public playercontroller player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(-0.07f, 0, 0);
        if (transform.position.x < -264.0f)
        {
            transform.position = new Vector3(192.0f, 8.0f, 0);
        }
    }
}
