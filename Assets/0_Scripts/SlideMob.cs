using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMob : MonoBehaviour
{
    [SerializeField] public float speed = 0.04f;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, 0, speed);

    }
}