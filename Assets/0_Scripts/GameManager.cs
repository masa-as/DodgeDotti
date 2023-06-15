using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject obj;
    private float _repeatSpan;    //繰り返す間隔
    private float _timeElapsed;   //経過時間
    private float _offset;
    private float z = 5.0f; //ノーツ開始のz座標
    private float degree = 30f; //斜めノーツの方向
    private List<float> speedList;
    [SerializeField] private float baseNoteSpeed = 0.08f;//ノーツ速度
    public GameObject SoundSystem;

    void Start()
    {
        obj = (GameObject)Resources.Load("Passerby");
        // Cubeプレハブを元に、インスタンスを生成、
        // Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        _repeatSpan = SoundSystem.GetComponent<BeatManager>().note_interval;  //実行間隔を設定
        _offset = z / baseNoteSpeed * 0.02f;
        _timeElapsed = -_offset;   //開始時間を調整
        speedList = CreateSpeedList();
    }

    private void FixedUpdate()
    {
        _timeElapsed += Time.deltaTime;     //時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan)
        {
            // 0:正面,1:左,2:右
            int direction = Random.Range(0,3);
            if(direction==0){
                float position = Random.Range(-2.0f,2.0f);
                obj.GetComponent<SlideMusicBox>().speed = speedList[0];
                Instantiate(obj, new Vector3(position, 0.5f, 5.0f), Quaternion.identity);
            }else if(direction==1){
                float position = Random.Range(-4.0f,-2.0f);
                obj.GetComponent<SlideMusicBox>().speed = speedList[1];
                Instantiate(obj, new Vector3(position, 0.5f, 5.0f), Quaternion.Euler(0f, -30f, 0f));
            }else if(direction==2){
                float position = Random.Range(2.0f,4.0f);
                obj.GetComponent<SlideMusicBox>().speed = speedList[2];
                Instantiate(obj, new Vector3(position, 0.5f, 5.0f), Quaternion.Euler(0f, 30f, 0f));
            }

            _timeElapsed -= _repeatSpan;   //経過時間を減らす
        }
    }
    private List<float> CreateSpeedList()
    {
        float radians = degree * Mathf.PI / 180.0f;
        float cos = Mathf.Cos(radians);
        float dist = z / cos; //斜め方向の移動距離
        float time = z / baseNoteSpeed;  //ベースの移動時間
        return new List<float> { baseNoteSpeed, dist / time, dist / time };
    }

}