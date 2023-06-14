using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float coef; //bpm Å® ï™ë¨ÇÃåWêî
    public bool display_speed;
    private float speed;

    void Start()
    {
        float bpm = GetComponent<BPMSoundPlayer>().bpm;
        speed = coef * bpm / 60; //ïbë¨Ç…ïœä∑
        if (display_speed)
        {
            Debug.Log("speed(m/ïb)="+speed);
        }
        speed *= 0.02f;  //0.02ïbë¨Ç…ïœä∑
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
