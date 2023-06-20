using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMob : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
