using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMusicBox : MonoBehaviour
{
    [SerializeField] public float speed = 0.08f;

    // Update is called once per frame
    void FixedUpdate()
    {

        //?g?????X?t?H?[????èÔ
        Transform myTransform = this.transform;

        //???W??èÔ
        Vector3 pos = myTransform.position;

        //z????????x
        pos.z -= speed;

        //???W????
        myTransform.position = pos;
    }
}