
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEffect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    // 生成したエフェクト保持
    public GameObject _particlePref1;
    private GameObject _particleObj1;


    // Update is called once per frame
    void Update()
    {
        //E押したら
        if (Input.GetKeyDown(KeyCode.E))
        {
            // エフェクトの位置を自分と同じ位置にする
            _particleObj1 = Instantiate(_particlePref1);
            _particleObj1.transform.position = transform.position;


        }
    }
}


