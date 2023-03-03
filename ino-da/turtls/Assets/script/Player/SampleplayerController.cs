using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SampleplayerController : MonoBehaviour
{
    private float speed = 0.4f; //���x

    [SerializeField]
    public float hp = 2;    //�q�b�g�|�C���g
    private float VerticalSpeed = 0.8f;    //�c�ړ��X�s�[�h
    private float speedText = 0;         //�e�L�X�g�p
    private float StopTime = 3;
    private int MoveStop = 0;
    private bool countStart;
    [SerializeField]
    private float StopPosition = 200.0f;    //�~�܂�ꏊ
    [SerializeField]
    private float Mag = 1;        //�{��
    bool one = true;        //��񂾂�����
    private float countDown = 3.0f; //�X�^�[�g�O�J�E���g
    private float Skip = 199.0f;
    private bool stopSkip = false;
    private float countStop = 5.0f;

    public Slider SPEEDbar; //�����X���C�_�[
    private int MaxSPEED = 100; //�X���C�_�[�}�b�N�X�o�����[�p�ϐ�
    private float SPEED = 0;
    private bool STOP = false;
    [SerializeField]
    private int Count = 0;          //����~�܂��Ă邩
    //private int SkipCount = 5;          //�X�L�b�v�ł����
    private float SceneMoveTime = 5.0f;         //Scene�ړ��ҋ@����
    

    private int SpeedLv;
    private int Point;
    [SerializeField]
    private float StartTime;

    //public List<float> SpeedList = new List<float>();
    //private float currentSpeed = 0.0f;
    //[SerializeField]
    //private int currentSpeed;

    private float SpeedValue = 0;
    private bool StartGame = false; 

    public GameObject Hp_object = null; //Hp�e�L�X�g
    public GameObject Speed_object = null; //Speed�e�L�X�g
    public GameObject Score_object = null; //Score�e�L�X�g
    public GameObject Already_object = null; //�ӖڃA�C�e��
    public GameObject Buff_object = null; //�o�t�e�L�X�g
    public GameObject Debuff_object = null; //�f�o�t�e�L�X�g
    public GameObject Expanation_object = null; //�����e�L�X�g

    [SerializeField]
    private bool Already = false;    //�Ӗ�
    private float AlreadyCount = 2;   //�Ӗڂ̎��ԃJ�E���g

    //private float currentTime = 0.0f; //���݂̎���


    private bool Confusion = false;      //���씽�]�t���O
    private float ConfusionCount = 2;    //���씽�]�̎��ԃJ�E���g
    private float Debufftime = 0;         //�f�o�t�c�莞��
    private float BuffTime = 0;         //�o�t�c�莞��
    private float DebuffCountTime;

    //private float MaxSpeed = 0.15f;
    public SpeedCameraMove speedCameraMove;

    private bool Invisible = false;     //���G�t���O
    private float InvisibleTime = 1.5f;      //���G����


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
        speed = float.Parse(speed.ToString("f4"));
        Vector2 position = transform.position;

        Text Buff_Text = Buff_object.GetComponent<Text>();
        Buff_Text.text = "BuffTime: " + InvisibleTime.ToString("f2");
        if (Already && Confusion)
        {
            DebuffCountTime = AlreadyCount + ConfusionCount;
        }
        else if (Already)
        {
            DebuffCountTime = AlreadyCount;
        }
        else if (Confusion)
        {
            DebuffCountTime = ConfusionCount;
        }

        Text Debuff_Text = Debuff_object.GetComponent<Text>();
        Debuff_Text.text = "DebuffTime: " + DebuffCountTime.ToString("f2");
        if (StartGame)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                
                if (transform.position.x > StopPosition)
                {
                    StopTime -= Time.deltaTime;
                    countStart = false;
                    if (one)
                    {
                        Count += 1;
                        Mag += 1;
                        one = false; 
                    }
                }
                else
                {
                    countStart = true;
                }
            }
        }
        if (StopTime <= MoveStop)
        {
            StopPosition += 200.0f;
            StopTime = 3;
            //StopPositionKeep = StopPosition;
            one = true;
        }

        if (!stopSkip && Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(Skip * Mag, transform.position.y, 0);
        }
        if (countStart)
        {

            position.x += speed;
            SPEEDbar.gameObject.SetActive(false);

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

            if (!stopSkip && Input.GetKeyDown(KeyCode.RightArrow))
            {
                position = new Vector3(Skip * Mag, transform.position.y, 0);
            }

            transform.position = position;
        }
        //currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            STOP = true;
        }
        //���b�������s��
        if (STOP)// && currentTime >= 0.01f)
        {
            SPEEDbar.value += 5;
            //currentTime = 0;

            //while (SPEEDbar.value >= MaxSPEED)
            if (SPEEDbar.value >= MaxSPEED)
            {
                SPEEDbar.value = 0;
            }
            if (!StartGame && Input.GetKeyDown(KeyCode.Space)) 
            {   //�X�y�[�X�L�[���͂Ŏ~�܂�
                STOP = false;
                SpeedValue = SPEEDbar.value;
                Debug.Log("STOP!!");
                StartGame = true;


                if (0 <= SpeedValue && SpeedValue < 20)
                {
                    speedText = 3f;
                    Text Speed_Text = Speed_object.GetComponent<Text>();
                    Speed_Text.text = "Speed:" + speedText;
                }
                else if (20 <= SpeedValue && SpeedValue < 40)
                {
                    speedText = 3.5f;
                    Text Speed_Text = Speed_object.GetComponent<Text>();
                    Speed_Text.text = "Speed:" + speedText;
                }
                else if (40 <= SpeedValue && SpeedValue < 60)
                {
                    speedText = 4f;
                    Text Speed_Text = Speed_object.GetComponent<Text>();
                    Speed_Text.text = "Speed:" + speedText;
                }
                else if (60 <= SpeedValue && SpeedValue < 80)
                {
                    speedText = 4.5f;
                    Text Speed_Text = Speed_object.GetComponent<Text>();
                    Speed_Text.text = "Speed:" + speedText;
                }
                else if (80 <= SpeedValue && SpeedValue < 100)
                {
                    speedText = 5f;
                    Text Speed_Text = Speed_object.GetComponent<Text>();
                    Speed_Text.text = "Speed:" + speedText;
                }  
            }
        }

        Text Hp_Text = Hp_object.GetComponent<Text>();
        Hp_Text.text = "Hp:" + hp;
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

        if (!Confusion && !Already)
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
            Debufftime = 2;
            if (!Already)
            {
                Debuff_object.gameObject.SetActive(false);
            }
        }

        if (Invisible)         //���G����
        {
            InvisibleTime -= Time.deltaTime;
        }
        if (InvisibleTime <= BuffTime)
        {
            Invisible = false;
            InvisibleTime = 1.5f;
            Buff_object.gameObject.SetActive(false);
        }

        Text Ex_Text = Expanation_object.GetComponent<Text>();
        switch (Count)
        {
            case 0:
                Ex_Text.text =
                    "Enter	:	�Q�[�W�X�^�[�g\n" +
                    "Space	:	�Q�[�W�X�g�b�v\n" +
                    "���� 		:	�ړ�\n\n" +
                    "�~�߂��o�[�̏ꏊ�ŃX�s�[�h���ω����邼.";
                break;
            case 1:
                Ex_Text.text =
                    "�����p�l���ƌ����p�l��\n" +
                    "����		:	�X�s�[�h�{0.5���v���C���[���E�Ɉړ�\n" +
                    "����		:	�X�s�[�h�[0.5���v���C���[�����Ɉړ�\n" +
                    "��ʊO�Ƀv���C��[���s���ƃQ�[���I�[�o�[�B";
                break;
            case 2:
                Ex_Text.text =
                    "�G\n" +
                    "�G�ɓ��������v���C���[�̃X�s�[�h��5�ȉ��̎��A�_���[�W\n" +
                    "6�ȏ�̎��́A�X�R�A+�P�O�O\n" +
                    "HP���O�ɂȂ�����Q�[���I�[�o�["; 
                break;
            case 3:
                Ex_Text.text =
                    "�A�C�e��\n" +
                    "�@�ӖځE�����E���G�E�{�[�i�X���o��\n" +
                    "�Ӗ�	:	2�b���肪�����Ȃ��Ȃ�@����	:	���씽�]\n" +
                    "���G	:	1.5�b�_���[�W���󂯂Ȃ��@\n" +
                    "�{�[�i�X	:	�X�R�A�{�T�O�O\n";
                break;
            case 4:
                Ex_Text.text =
                    "�M�~�b�N\n" +
                    "�@���E�󂹂�ǂ��o��\n" +
                    "��				:	�擾�Ń{�[�i�X�X�e�[�W�ɍs���邼\n" +
                    "�󂹂��	�F	�X�s�[�h7�ȏ�̎��j��\\n\n" +
                    "�{�[�i�X�X�e�[�W����ŃR�C���o��\n" +
                    "�R�C��		�F	�X�R�A�{�P�O�O";
                break;
            case 5:
                Ex_Text.text = "\n\n�X�R�A�����N��SS�`D�܂ł��邼\n\n" +
                    "SS�ڎw���Ċ撣�낤�I�I�I";
                stopSkip = true;
                SceneMoveTime -= Time.deltaTime;
                break;
            default:
                break;
        }
        if(Count >= countStop)
        {
            Count = 5;
        }
        if (SceneMoveTime <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnCollisionEnter2D(Collision2D col)// �����蔻��
    {
        if (col.gameObject.tag == "Enemy")
        {
                Debug.Log("hit Player");
                hp -= col.gameObject.GetComponent<enemycontroller>().powerEnemy;
        }
        if (col.gameObject.tag == "Enemy2")
        {
                Debug.Log("hit");
                Point += 100;
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other) //�g���K�[�������蔻��
    {

        if (other.gameObject.tag == "SpeedUp")
        {
            Debug.Log("Speed UP");
            speedText += 0.5f;
            Text Speed_Text = Speed_object.GetComponent<Text>();
            Speed_Text.text = "Speed:" + speedText;
            speedCameraMove.one1 = true;
        }
        if (other.gameObject.tag == "SpeedDown")
        {
            Debug.Log("Speed Down");
            speedText -= 0.5f;
            Text Speed_Text = Speed_object.GetComponent<Text>();
            Speed_Text.text = "Speed:" + speedText;
            speedCameraMove.one2 = true;
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
            Invisible = true;
        }
        if (other.gameObject.tag == "BORNUS")         //�{�[�i�X�A�C�e��
        {
            Debug.Log("NICE!!");
            Point += 500;
        }
    }
}

