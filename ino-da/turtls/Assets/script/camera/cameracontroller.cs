using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class cameracontroller : MonoBehaviour
{
    GameObject playerObj;
    playercontroller player;
    Transform playerTransform;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Camera");
        player = playerObj.GetComponent<playercontroller>();
        playerTransform = playerObj.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //â°ï˚å¸ÇæÇØí«è]
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}