
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorMaterial : MonoBehaviour
{
    public Material colorA;

    // Use this for initialization
    void Start()
    {

    }
    public GameObject _particlePref;
    // 生成したエフェクト保持
    private GameObject _particleObj;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Renderer>().material.color = colorA.color;
        _particleObj = Instantiate(_particlePref);
        // エフェクトの位置を自分と同じ位置にする
        _particleObj.transform.position = transform.position;

    }


}


