using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamefade : MonoBehaviour
{
    float fadetimer;

    /*Fadeout fadeManager;
    public GameObject ManageObject;
    public GameObject Title_object = null;//タイトルテキスト

    // Start is called before the first frame update
    void Start()
    {
        fadeManager = ManageObject.GetComponent<Fadeout>();
    }
    */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            /*fadetimer += Time.deltaTime;
            if (fadetimer == 1.5f)
            {*/
                SceneManager.LoadScene("SampleScene");
            //}
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
