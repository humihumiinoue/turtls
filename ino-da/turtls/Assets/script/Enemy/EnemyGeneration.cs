using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject PrefabEnemy;
    public bool EnemyLoop = true;

    public warp warp;

    bool count = true;

    private int repetition = 0; //ÉãÅ[Évópint
    [SerializeField]
    private int repeat = 4;  //ìGê∂ê¨êî
    private float x1 = 39.0f, x2 = 340.0f;
    private float y1 = 11.0f, y2 = 14.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (count && warp.warp_count % 6 == 0)
        {
            repeat += 3;
        }
        count = false;

        while (EnemyLoop) {
            repetition += 1;
            float x = Random.Range(x1, x2);
            float y = Random.Range(y1, -y2);
            Vector3 pos = new Vector3(x, y, 0.0f);
            //ìGÇê∂ê¨
            if (!Physics.CheckBox(pos, transform.position, Quaternion.identity, 1 << 12))
            {
                Instantiate(PrefabEnemy, pos, Quaternion.identity);
            }
            if (repetition >= repeat)
            {
                EnemyLoop = false;
                repetition = 0;
                count = true;
            }

        }
    }
}
