
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEffect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    // ���������G�t�F�N�g�ێ�
    public GameObject _particlePref1;
    private GameObject _particleObj1;


    // Update is called once per frame
    void Update()
    {
        //E��������
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �G�t�F�N�g�̈ʒu�������Ɠ����ʒu�ɂ���
            _particleObj1 = Instantiate(_particlePref1);
            _particleObj1.transform.position = transform.position;


        }
    }
}


