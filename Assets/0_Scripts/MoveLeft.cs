using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] public float speed = 0.01f;
    void Start()
    {
        Destroy(gameObject, 1f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(0, speed, 0);

    }
}
