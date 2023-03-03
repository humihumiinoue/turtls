using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    public GameObject PrefabCoin;
    public bool CoinLoop = false;

    private int repetition = 0; //ƒ‹[ƒv—pint
    private int CoinCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        while (CoinLoop)
        {
            repetition++;
            float x = Random.Range(1415.0f, 1820.0f);
            float y = Random.Range(11.0f, -5.0f);
            Vector3 pos = new Vector3(x, y, 0.0f);
            //“G‚ð¶¬
            Instantiate(PrefabCoin, pos, Quaternion.identity);
            if (repetition >= CoinCount)
            {
                CoinLoop = false;
                repetition = 0;
            }
        }
    }
}
