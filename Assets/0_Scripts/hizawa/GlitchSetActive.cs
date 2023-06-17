using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSetActive: MonoBehaviour
{
    //public GameObject beam;
    //OVRGrabbable grabbable;


    //Start関数より最初に実行される関数。
    //コンポーネントの取得処理でよく使います
    //private void Awake()
    //{
    //    grabbable = GetComponent<OVRGrabbable>();
    //}

    //フレーム毎に実行
    void Update()
    {

        //void Glitch()
        //{
            //右コントローラのトリガーボタン、もしくは左コントローラーのトリガーボタンが押されている間
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
            Debug.Log("trigger");
            GetComponent<PostEffect>().enabled = true;
        }
        //}
    }
}


