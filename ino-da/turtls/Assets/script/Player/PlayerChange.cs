using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public GameObject Player_fast;
    public GameObject Player_slow;

    public playercontroller playerController;

    public PlayerTurn PlayerTurn;
    [SerializeField]
    private float PlayerSpeed;      //�v���C���[�X�s�[�h
    private float ChangeSpeed = 0.45f;  //�G��|����X�s�[�h

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = playerController.speed;
        if (PlayerSpeed >= ChangeSpeed)
        {
            Player_slow.gameObject.SetActive(false); //���݂̃I�u�W�F�N�g��false
            Player_fast.gameObject.SetActive(true); //�ʂ̃I�u�W�F�N�g���N��

            PlayerTurn.StartCount = true;
        } else if (PlayerSpeed < ChangeSpeed)
        {
            Player_slow.gameObject.SetActive(true);
            Player_fast.gameObject.SetActive(false);
            PlayerTurn.count = 0;
            PlayerTurn.StartCount = false;
        }

    }
}
