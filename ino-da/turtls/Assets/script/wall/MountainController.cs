using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainController : MonoBehaviour
{
    public bool MountStart = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
if(MountStart)
        {
            transform.Translate(-0.12f, 0, 0);
        }
        if (transform.position.x < -413f)
        {
            transform.position = new Vector3(38.5f, -6.65f, 0);
        }
    }
}
