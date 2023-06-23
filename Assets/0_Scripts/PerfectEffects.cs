using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectEffects : MonoBehaviour
{
    GameObject obj;
    GameObject obj2;
    void Start()
    {
        obj = (GameObject)Resources.Load("PerfectEffects");
        obj2 = (GameObject)Resources.Load("judge_p");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject particle = Instantiate(obj, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 3.0f), Quaternion.identity);
            particle.transform.parent = this.transform;

            GameObject judge = Instantiate(obj2, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 1.0f), Quaternion.Euler(90f, 180f, 0f));
            judge.transform.parent = this.transform;
        }
    }
}
