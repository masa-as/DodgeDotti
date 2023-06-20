using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TochouMove : MonoBehaviour
{
    Vector3 pos;
    [SerializeField] private float speed, stop_pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        if (pos.z >= stop_pos) {
            pos.z -= speed;
            myTransform.position = pos;
        }
        else
        {
            StartCoroutine(WaitAndPrint());
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(3);
    }
}
