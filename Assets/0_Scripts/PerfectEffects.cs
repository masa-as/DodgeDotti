using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectEffects : MonoBehaviour
{
    GameObject obj;
    void Start()
    {
        obj = (GameObject)Resources.Load("PerfectEffects");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject particle = Instantiate(obj, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 0.5f), Quaternion.identity);

            particle.transform.parent = this.transform;

        }
    }
}
