using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject obj;
    private float _repeatSpan;    //繰り返す間隔
    private float _timeElapsed;   //経過時間


    void Start()
    {
        obj = (GameObject)Resources.Load("Passerby");
        // Cubeプレハブを元に、インスタンスを生成、
        // Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        _repeatSpan = 1;    //実行間隔を設定
        _timeElapsed = 0;   //経過時間をリセット
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;     //時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan)
        {
            float rnd = Random.Range(-2.0f,2.0f);
            //ここで処理を実行
            Instantiate(obj, new Vector3(rnd, 0.5f, 5.0f), Quaternion.identity);

            _timeElapsed = 0;   //経過時間をリセットする
        }
    }
}