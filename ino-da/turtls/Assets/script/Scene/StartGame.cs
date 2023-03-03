using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    float fadetimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().name == "StartScene")
        {
            fadetimer += Time.deltaTime;
            if (fadetimer == 1.5f)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "StartScene")
        {
            fadetimer += Time.deltaTime;
            if (fadetimer == 1.5f)
            {
                SceneManager.LoadScene("ExplamationScene");
            }
        }
    }
}