using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    public float speed = 0; //���x
    private float[] StartSpeed = new float[5];
    
    [SerializeField]
    public float hp = 2;    //�q�b�g�|�C���g
    private float VerticalSpeed = 0.4f;    //�c�ړ��X�s�[�h

    public Slider SPEEDbar; //�����X���C�_�[
    private int MaxSPEED = 100; //�X���C�_�[�}�b�N�X�o�����[�p�ϐ�
    private float SPEED = 0;
    private bool STOP = false;

    private int SpeedLv;
    private bool SLv1 = false;
    private bool SLv2 = false;
    private bool SLv3 = false;
    private bool SLv4 = false;
    private bool SLv5 = false;
    //public List<float> SpeedList = new List<float>();
    //private float currentSpeed = 0.0f;
    //[SerializeField]
    //private int currentSpeed;

    private bool StopOne = true;        //�Q�[�W�X�g�b�v��񂾂�����
    private bool StopOne2 = true;

    private float SpeedValue = 0;
    private float StartTime = 3;    //�Q�[���X�^�[�g�J�E���g
    public bool StartGame = false; // �Q�[���X�^�[�g�J�E���g�_�E��
    int seconds;    //�J�E���g�_�E��UI�p
    private float BreakEnemy = 0.45f;    //�G��|����X�s�[�h
    private float SlowSpeed = 0.1f;

    public static int Point;    //�V�[�����ς���Ă����L�ł���

    public GameObject count_object = null; //count�e�L�X�g
    public GameObject Hp_object = null; //Hp�e�L�X�g
    public GameObject Speed_object = null; //Speed�e�L�X�g
    public GameObject Score_object = null; //Score�e�L�X�g
    public GameObject Already_object = null; //�ӖڃA�C�e��
    public GameObject Buff_object = null; //�o�t�e�L�X�g
    public GameObject Debuff_object = null; //�f�o�t�e�L�X�g

    [SerializeField]
    private bool Already = false;    //�Ӗ�
    private float AlreadyCount = 2;   //�Ӗڂ̎��ԃJ�E���g
    public Slider slider;   //�X���C�_�[
    
    //private float currentTime = 0.0f; //���݂̎���

    public SpeedCameraMove speedCameraMove;
    public GameOverController gameOver;


    private bool Confusion = false;      //���씽�]�t���O
    private float ConfusionCount = 2;    //���씽�]�̎��ԃJ�E���g
    private float Debufftime = 0;         //�f�o�t�c�莞��
    private float BuffTime = 0;         //�o�t�c�莞��
    private float DebuffCountTime;

    private float MaxSpeed = 1.5f;

    private bool Invisible = false;     //���G�t���O
    private float InvisibleTime = 1.5f;      //���G����

    public MountainController mountain;

    public GameObject Player_fast;
    public GameObject Player_slow;

    // Start is called before the first frame update
    void Start()
    {
        
        SPEEDbar.maxValue = MaxSPEED;
        
        SPEEDbar.value = SPEED;

        Point = 0;

    }

    // Update is called once per frame
    void Update()
    {

        float[] StartSpeed = { 0.3f, 0.35f, 0.4f, 0.45f, 0.5f };
        speed = float.Parse(speed.ToString("f4"));
        Vector2 position = transform.position;

        Text Buff_Text = Buff_object.GetComponent<Text>();
        Buff_Text.text = "BuffTime: " + InvisibleTime.ToString("f2");
        if (Already && Confusion)
        {
            DebuffCountTime = AlreadyCount + ConfusionCount;
        }else if (Already)
        {
            DebuffCountTime = AlreadyCount;
        }else if (Confusion)
        {
            DebuffCountTime = ConfusionCount;
        }

        Text Debuff_Text = Debuff_object.GetComponent<Text>();
        Debuff_Text.text = "DebuffTime: " +DebuffCountTime.ToString("f2");

        if (StartGame)
        {
            StartTime -= Time.deltaTime;
            seconds = (int)StartTime;
            Text count_Text = count_object.GetComponent<Text>();
            count_Text.text = "" + seconds;
            
        }
        if (StartTime <= 0)
        {
            mountain.MountStart = true;
            StartGame = false;
            position.x += speed;
            slider.gameObject.SetActive(false);
            count_object.gameObject.SetActive(false);


            if (!Confusion && Input.GetKey("up"))
            {
                position.y += VerticalSpeed;
            }
            else if (!Confusion && Input.GetKey("down"))
            {
                position.y -= VerticalSpeed;
            }
            else if (Confusion && Input.GetKey("up"))
            {
                position.y -= VerticalSpeed;
            }
            else if (Confusion && Input.GetKey("down"))
            {
                position.y += VerticalSpeed;
            }

            transform.position = position;
        }

        if (speed >= MaxSpeed)
        {
            speed = MaxSpeed;
        }

        //currentTime += Time.deltaTime;
        if (StopOne && Input.GetKeyDown(KeyCode.Return))
        {
            STOP = true;
            StopOne = false;
        }
            //���b�������s��
            if (STOP)// && currentTime >= 0.01f)
        {
            SPEEDbar.value += 7;
            //currentTime = 0;

            //while (SPEEDbar.value >= MaxSPEED)
            if (SPEEDbar.value >= MaxSPEED)
            {
                SPEEDbar.value = 0;
            }
            if (StopOne2 && Input.GetKeyDown(KeyCode.Space))
            {   //�X�y�[�X�L�[���͂Ŏ~�܂�
                STOP = false;
                SpeedValue = SPEEDbar.value;
                Debug.Log("STOP!!");
                StartGame = true;
                StopOne2 = false;


                if (0 <= SpeedValue && SpeedValue < 20)
                {
                    SLv1 = true;
                }
                else if (20 <= SpeedValue && SpeedValue < 40)
                {
                    SLv2 = true;
                }
                else if (40 <= SpeedValue && SpeedValue < 60)
                {
                    SLv3 = true;
                }
                else if (60 <= SpeedValue && SpeedValue < 80)
                {
                    SLv4 = true;
                }
                else if (80 <= SpeedValue && SpeedValue < 100)
                {
                    SLv5 = true;
                }   //���x���ɂ���ăX�s�[�h�����߂�
            }

        }

        if (SLv1)
        {
            speed = StartSpeed[0];
            SLv1 = false;
        }
        if (SLv2)
        {
            speed = StartSpeed[1];
            SLv2 = false;
        }
        if (SLv3)
        {
            speed = StartSpeed[2];
            SLv3 = false;
        }
        if (SLv4)
        {
            speed = StartSpeed[3];
            SLv4 = false;
        }
        if (SLv5)
        {
            speed = StartSpeed[4];
            SLv5 = false;
        }

        if (speed < SlowSpeed)
        {
            speed = SlowSpeed;
        }

        Text Hp_Text = Hp_object.GetComponent<Text>();
        Hp_Text.text = "Hp:" + hp;
        Text Speed_Text = Speed_object.GetComponent<Text>();
        Speed_Text.text = "Speed:" + speed * 10;
        Text Score_Text = Score_object.GetComponent<Text>();
        Score_Text.text = "Score:" + Point.ToString("D4");

        if (Already)
        {
            AlreadyCount -= Time.deltaTime;
            if (AlreadyCount <= Debufftime)
            {
                Already = false;
                Already_object.gameObject.SetActive(false); 
                if (!Confusion)
                {
                    Debuff_object.gameObject.SetActive(false);
                }
                AlreadyCount = 2;
            }
        }

        if(!Confusion&& !Already)
        {
            Debuff_object.gameObject.SetActive(false);
        }

        if (Confusion)         //���]����
        {
            ConfusionCount -= Time.deltaTime;
        }
        if (ConfusionCount <= Debufftime)
        {
            Confusion = false;
            ConfusionCount = 2;
            if (!Already)
            {
                Debuff_object.gameObject.SetActive(false);
            }
        }

        if (Invisible)         //���G����
        {
            InvisibleTime -= Time.deltaTime;
            Player_slow.gameObject.SetActive(false); //���݂̃I�u�W�F�N�g��false
            Player_fast.gameObject.SetActive(true); //�ʂ̃I�u�W�F�N�g���N��
        }
        if (InvisibleTime <= BuffTime)
        {
            Invisible = false;
            InvisibleTime = 1.5f;
            Buff_object.gameObject.SetActive(false);
            Player_slow.gameObject.SetActive(true);
            Player_fast.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)// �����蔻��
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (speed >= BreakEnemy)
            {
                Debug.Log("hit");
                Point += 100;
                
            }
            else
            {
                Debug.Log("hit Player");

                hp -= col.gameObject.GetComponent<enemycontroller>().powerEnemy;
            }
        }
        if (hp <= 0)
        {
            Debug.Log("Die");
            SceneManager.LoadScene("gameovescene");
        }
    }
    public void OnTriggerEnter2D(Collider2D other) //�g���K�[�������蔻��
    {
        
        if (other.gameObject.tag == "SpeedUp")
        {
            Debug.Log("Speed UP");
            speed += 0.05f;
            speedCameraMove.one1 = true;
            gameOver.one1 = true;
        }
        if (other.gameObject.tag == "SpeedDown")
        {
            Debug.Log("Speed Down");
            speed -= 0.05f;
            speedCameraMove.one2 = true;
            gameOver.one2 = true;
        }
        if (other.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene("gameovescene");
        }
        if (other.gameObject.tag == "Key")
        {
            warp warp = GetComponent<warp>();
            warp.Bonus = true;
        }
        if (other.gameObject.tag == "coin")
        {
            Debug.Log("Get Coin");
            Point += 100;
        }

        if (other.gameObject.tag == "Already")
        {
            Debug.Log("Already");
            Already = true;
            Already_object.gameObject.SetActive(true);
            Debuff_object.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Confusion")
        {
            Debug.Log("CONFUSION!");
            Confusion = true;
            Debuff_object.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Invisible")
        {
            Debug.Log("Invisible!!");
            Buff_object.gameObject.SetActive(true);
            if (speed < BreakEnemy)
            {
                Invisible = true;
            }
            else
            {
                Point += 300;
            }
        }
        if (other.gameObject.tag == "BORNUS")         //�{�[�i�X�A�C�e��
        {
            Debug.Log("NICE!!");
            Point += 500;
        }
    }
}
