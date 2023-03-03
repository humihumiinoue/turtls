using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadeout : MonoBehaviour
{

    private bool isFadeOut = false;//�t�F�[�h�A�E�g�t���O
    private bool isFadeIn = true;   //�t�F�[�h�C���t���O
    float fadeSpeed = 0.75f;        //�����x���ς��X�s�[�h
    public Image fadeImage;         //�t�F�[�h�摜���擾
    float red, green, blue, color;
    string afterScene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SetRGBA(0, 0, 0, 1);
        SceneManager.sceneLoaded += fadeInStart;       
        //�V�[���J�ڊ������Ƀt�F�[�h�C���J�n
    }

    void fadeInStart(Scene scene,LoadSceneMode mode)
    {
        isFadeIn = true;
    }

    public  void fadeOutStart(int red,int green,int blue,int color,string nextScene)
    {
        SetRGBA(red, green, blue, color);
        SetColor();
        isFadeOut = true;
        afterScene = nextScene;
    }

 
    void Update()
    {
        fadeMain();
    }
    void SetColor()//�F����֐�
    {
        fadeImage.color = new Color(red, green, blue, color);
    }
    public void SetRGBA(int r,int g,int b,int c)
    {
        red = r;
        green = g;
        blue = b;
        color = c;
    }

    private void fadeMain()
    {
        float fadeColor = 1.0f;
        if (isFadeIn == true)
        {
            color -= fadeSpeed * Time.deltaTime;    //時間とともに透明になる
            SetColor();                             
            if (color <= 0)                         //透明になったら
                isFadeIn = false;                   //止まる
        }
        if (isFadeOut == true)
        {
            color += fadeSpeed * Time.deltaTime;    //時間とともに暗くなる
            SetColor();
            if (color <= 0)
                isFadeIn = false;
        }
        if (isFadeOut == true)
        {
            color += fadeSpeed * Time.deltaTime;    //時間とともに暗くなる
            SetColor();
            if (color >= fadeColor)
            {
                isFadeOut = false;                  
                SceneManager.LoadScene(afterScene); //シーンの読み込み
            }
        } 
    }
}
