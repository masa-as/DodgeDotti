using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSetActive: MonoBehaviour
{
    //public GameObject beam;
    //OVRGrabbable grabbable;


    //Start�֐����ŏ��Ɏ��s�����֐��B
    //�R���|�[�l���g�̎擾�����ł悭�g���܂�
    //private void Awake()
    //{
    //    grabbable = GetComponent<OVRGrabbable>();
    //}

    //�t���[�����Ɏ��s
    void Update()
    {

        //void Glitch()
        //{
            //�E�R���g���[���̃g���K�[�{�^���A�������͍��R���g���[���[�̃g���K�[�{�^����������Ă����
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
            Debug.Log("trigger");
            GetComponent<PostEffect>().enabled = true;
        }
        //}
    }
}


