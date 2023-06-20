using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDPerson : MonoBehaviour
{
    public float distance;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 positionXZ = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 originXZ = new Vector3(0, 0, 0);
        float distance = Vector3.Distance(positionXZ, originXZ);
    }

}
