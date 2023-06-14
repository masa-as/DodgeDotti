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
            // 0:正面,1:左,2:右
            int direction = Random.Range(0,3);
            if(direction==0){
                float position = Random.Range(-2.0f,2.0f);
                Instantiate(obj, new Vector3(position, 0.5f, 5.0f), Quaternion.identity);
            }else if(direction==1){
                float position = Random.Range(-4.0f,-2.0f);
                Instantiate(obj, new Vector3(position, 0.5f, 5.0f), Quaternion.Euler(0f, -30f, 0f));
            }else if(direction==2){
                float position = Random.Range(2.0f,4.0f);
                Instantiate(obj, new Vector3(position, 0.5f, 5.0f), Quaternion.Euler(0f, 30f, 0f));
            }

            _timeElapsed = 0;   //経過時間をリセットする
        }
    }
}