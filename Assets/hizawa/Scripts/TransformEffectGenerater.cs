
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorMaterial : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public GameObject _particlePref;
    // 生成したエフェクト保持
    private GameObject _particleObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _particleObj = Instantiate(_particlePref);
            // エフェクトの位置を自分と同じ位置にする
            _particleObj.transform.position = transform.position;
        }
    }


}


