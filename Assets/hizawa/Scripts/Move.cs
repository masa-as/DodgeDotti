using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    //RigidBody’è‹`
    public Rigidbody rigidbody;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0.01f, 0, 0);
    }
}