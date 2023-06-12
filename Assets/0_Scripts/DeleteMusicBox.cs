using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMusicBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        if (myTransform.position.z < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
