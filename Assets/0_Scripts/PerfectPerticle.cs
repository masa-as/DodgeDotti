using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectPerticle : MonoBehaviour
{
    GameObject obj;
    void Start()
    {
        obj = (GameObject)Resources.Load("SmallStars");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colisiontest");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("colisiontest2");
            GameObject particle = Instantiate(obj, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 0.5f), Quaternion.identity);

            particle.transform.parent = this.transform;

        }
    }
}
