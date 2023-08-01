using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MobGenerator_START : MonoBehaviour
{
    private float _repeatSpan = 0.2f;    //繰り返す間隔
    private float _timeElapsed;   //経過時間


    //表示させるmobリスト
    public List<GameObject> mob_list = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        read_img(6);
    }

    //リソースから表示させたい画像を指定した個数だけ読み込む関数
    public void read_img(int n)
    {
        GameObject tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = (GameObject)Resources.Load("Mobs/Female" + i);
            mob_list.Add(tmp);
        }
    }

    //ボタンで呼び出される関数
    public void GenerateMob()
    {
        //１～表示する画像の数をランダムで算出
        int random = Random.Range(1, mob_list.Count);
        //int rnd = Random.Range(0, 2);
        float rnd_position = Random.Range(-40.0f, 40.0f);
        /*if (rnd == 0)
        {
            rnd_position = Random.Range(-40.0f, 2.0f);
        }
        if (rnd == 1)
        {
            rnd_position = Random.Range(-2.0f, 40.0f);
        }*/
        Instantiate(mob_list[random], new Vector3(rnd_position, 0f, 30.0f), Quaternion.Euler(0f, 220f, 0f));
    }
    private void FixedUpdate()
    {
        _timeElapsed += Time.deltaTime;     //時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan)
        {
            GenerateMob();
            _timeElapsed -= _repeatSpan;   //経過時間を減らす
        }

    }
}