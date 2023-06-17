using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMusicBox : MonoBehaviour
{
    [SerializeField] public float speed = 0.8f;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, 0, speed);
        
    }
}