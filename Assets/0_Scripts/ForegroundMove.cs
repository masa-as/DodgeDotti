using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float coef; //bpm �� �����̌W��
    public bool display_speed;
    private float speed;

    void Start()
    {
        float bpm = GetComponent<BeatManager>().bpm;
        speed = coef * bpm / 60; //�b���ɕϊ�
        if (display_speed)
        {
            Debug.Log("speed(m/�b)="+speed);
        }
        speed *= 0.02f;  //0.02�b���ɕϊ�
    }

    // Update is called once per frame(0.02sec)
    void FixedUpdate()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.z -= speed;
        myTransform.position = pos;
    }
}
