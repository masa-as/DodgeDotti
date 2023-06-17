using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject obj;
    private float _repeatSpan;    //繰り返す間隔
    private float _timeElapsed;   //経過時間
    private float _offset;
    private float _z = 5.0f; //ノーツ開始のz座標
    private float _degree = 30f; //斜めノーツの方向
    private List<float> speedList;
    [SerializeField] private float baseNoteSpeed = 0.08f;//ノーツ速度
    public GameObject SoundSystem;

    void Start()
    {
        // Cubeプレハブを元に、インスタンスを生成、
        // Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        _repeatSpan = SoundSystem.GetComponent<BeatManager>().note2interval[SoundSystem.GetComponent<BeatManager>().note];  //実行間隔を設定
        _offset = _z / baseNoteSpeed * 0.02f;
        _timeElapsed = -_offset;   //開始時間を調整
        speedList = CreateSpeedList();
    }

    private void FixedUpdate()
    {
        _timeElapsed += Time.deltaTime;     //時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan)
        {
            int model = Random.Range(0, 4);
            if (model == 0)
            {
                obj = (GameObject)Resources.Load("Female1_Mono");
            }
            else if (model == 1)
            {
                obj = (GameObject)Resources.Load("Male1_Mono");
            }
            else if (model == 2)
            {
                obj = (GameObject)Resources.Load("Male2_Mono");
            }
            else if (model == 3)
            {
                obj = (GameObject)Resources.Load("Male3_Mono");
            }
            // 0:正面,1:左,2:右
            int direction = Random.Range(0,3);
            if(direction==0){
                float position = Random.Range(-2.0f,2.0f);
                obj.GetComponent<SlideMusicBox>().speed = speedList[0];
                Instantiate(obj, new Vector3(position, 0f, 5.0f), Quaternion.Euler(0f, 180f, 0f));
            }else if(direction==1){
                float position = Random.Range(-4.0f,-2.0f);
                obj.GetComponent<SlideMusicBox>().speed = speedList[1];
                Instantiate(obj, new Vector3(position, 0f, 5.0f), Quaternion.Euler(0f, 150f, 0f));
            }else if(direction==2){
                float position = Random.Range(2.0f,4.0f);
                obj.GetComponent<SlideMusicBox>().speed = speedList[2];
                Instantiate(obj, new Vector3(position, 0f, 5.0f), Quaternion.Euler(0f, 210f, 0f));
            }

            _timeElapsed -= _repeatSpan;   //経過時間を減らす
            _repeatSpan = SoundSystem.GetComponent<BeatManager>().note2interval[SoundSystem.GetComponent<BeatManager>().note];
        }
    }
    private List<float> CreateSpeedList()
    {
        float radians = _degree * Mathf.PI / 180.0f;
        float cos = Mathf.Cos(radians);
        return new List<float> { baseNoteSpeed, baseNoteSpeed / cos, baseNoteSpeed / cos};
    }

}