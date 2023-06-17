
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEffect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public GameObject _particlePref1;
    // 生成したエフェクト保持
    private GameObject _particleObj1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _particleObj1 = Instantiate(_particlePref1);
            // エフェクトの位置を自分と同じ位置にする
            _particleObj1.transform.position = transform.position;

            
        }
    }


}


