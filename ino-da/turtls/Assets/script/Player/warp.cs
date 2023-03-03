using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    public bool Bonus = false;

    public EnemyGeneration enemyGeneration;
    public ItemGeneration itemGeneration;
    public CoinGeneration coinGeneration;
    public WallGenerator2 wallGenerator2;
    public WallGenerator1 wallGenerator1;

    public int warp_count = 1;
    private float BonusCount = 3.0f;    //Bonusエリアに入るまでの時間
    private float upTime = 0;
    private bool BonusTime = false;

    public GameObject Start_object = null;   // スタート位置
    public GameObject Bonus_object = null;   // Bonusテキスト

     private GameObject[] WallPrefab;
    private bool Warp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Warp)
        {
            if (transform.position.y > 14.0f)
            {
                transform.position = new Vector3(transform.position.x, -14.0f, 0);
            }
            else if (transform.position.y < -14.0f)
            {
                transform.position = new Vector3(transform.position.x, 14.0f, 0);
            }
        }
        if (!Bonus && transform.position.x > 390.0f && transform.position.x < 550.0f)
        {
            transform.position = new Vector3(0.0f, transform.position.y, 0);
            playercontroller playerController = GetComponent<playercontroller>();
            playerController.speed += 0.05f;
            enemyGeneration.EnemyLoop = true;
            wallGenerator2.Generation = true;
            wallGenerator1.Generation = true;
            Start_object.gameObject.SetActive(false);
            warp_count += 1;
            WallPrefab = GameObject.FindGameObjectsWithTag("wall");
            for (int i = 0; i < WallPrefab.Length; ++i) {
                Destroy(WallPrefab[i]);
            }
        }
        else if(Bonus && transform.position.x > 365.0f && transform.position.x < 370.0f)
        {
            BonusTime = true;
            Bonus_object.gameObject.SetActive(true);
            playercontroller playerController = GetComponent<playercontroller>();
            playerController.speed += 0.5f;
            coinGeneration.CoinLoop = true;
            Bonus = false;
        }
        if(transform.position.x > 1840.0f && transform.position.x < 1860.0f)
        {
            transform.position = new Vector3(0.0f, transform.position.y, 0);
            playercontroller playerController = GetComponent<playercontroller>();
            playerController.speed -= 0.5f;
            enemyGeneration.EnemyLoop = true;
            itemGeneration.ItemLoop = true;
            wallGenerator2.Generation = true;
            wallGenerator1.Generation = true;
            Start_object.gameObject.SetActive(false);
            warp_count += 1;
            WallPrefab = GameObject.FindGameObjectsWithTag("wall");

            for (int i = 0; i < WallPrefab.Length; ++i)
            {
                Destroy(WallPrefab[i]);
            }
        } 
         if(BonusTime)
        {
            Warp = false;
            upTime += 1;
            BonusCount -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + upTime, 0);
            if (BonusCount <= 0)
            {
                upTime = 0;
                BonusCount = 3.0f;
                transform.position = new Vector3(1320.0f, transform.position.y, 0);
                Bonus_object.gameObject.SetActive(false);
                BonusTime = false;
                Warp = true;
            }
        }
    }
}

