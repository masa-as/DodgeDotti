using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float coef; //bpm → 分速の係数
    private float speed;

    void Start()
    {
        float bpm = GetComponent<BPMSoundPlayer>().bpm;
        speed = coef * bpm / 60; //秒速に変換
        speed *= 0.2f;  //0.2秒速に変換
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        pos.z -= speed;

        myTransform.position = pos;
    }
}
