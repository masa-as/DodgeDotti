using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float coef; //bpm �� �����̌W��
    public bool display_speed;
    private float speed;

    private GameObject soundSystem;

    void Start()
    {
        soundSystem = GameObject.Find("SoundSystem");
        float bpm = soundSystem.GetComponent<BeatManager>().bpm;
        speed = coef * bpm / 60; //�b���ɕϊ�
        if (display_speed)
        {
            Debug.Log("speed(m/�b)=" + speed);
        }
        speed *= 0.02f;  //0.02�b���ɕϊ�
    }

    // Update is called once per frame(0.02sec)
    void FixedUpdate()
    {
        if (display_speed)
        {
            Debug.Log("speed(m/�b)=" + speed);
        }
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.z -= speed;
        myTransform.position = pos;
    }
}
