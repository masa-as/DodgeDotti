
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
    // ���������G�t�F�N�g�ێ�
    private GameObject _particleObj;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Renderer>().material.color = colorA.color;
        _particleObj = Instantiate(_particlePref);
        // �G�t�F�N�g�̈ʒu�������Ɠ����ʒu�ɂ���
        _particleObj.transform.position = transform.position;

    }


}


