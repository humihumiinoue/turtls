using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeManager : MonoBehaviour
{

    Fadeout fadeManager;
    public GameObject ManageObject;
    public GameObject Title_object = null;

    // Start is called before the first frame update
    void Start()
    {
        fadeManager = ManageObject.GetComponent<Fadeout>();
    }

    // Update is called once per frame
    void Update()
    {
        fadeManegiment();
    }

    private void fadeManegiment()
    {
        //エンターキーが押されたら　かつ　スタートシーンだったら
        if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().name == "StartScene")
        {
            fadeManager.fadeOutStart(0, 0, 0, 0, "SampleScene");
        }
        //スペースキーが押されたら　かつ　スタートシーンだったら
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "StartScene")
        {
            fadeManager.fadeOutStart(0, 0, 0, 0, "ExplamationScene");
        }
        //エンターキーが押されたら　かつ　ゲームオーバーシーンだったら
        if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().name == "gameoverscene")
        {
            fadeManager.fadeOutStart(0, 0, 0, 0, "SampleScene");
        }
        //スペースキーが押されたら　かつ　ゲームオーバーシーンだったら
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "gameoverscene")
        {
            fadeManager.fadeOutStart(0, 0, 0, 0, "StartScene");
        }
    }
}
