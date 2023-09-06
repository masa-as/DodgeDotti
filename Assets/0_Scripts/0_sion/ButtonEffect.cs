using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{



    private void Start()
    {
        DOTween.Init();

        //拡大縮小
        transform.DOScale(new Vector3(1.01f, 1.01f, 1.01f), 0.5f)
            .SetLoops(-1, LoopType.Yoyo);
        //フェードで光る
       /*var image = GetComponent<Image>();
        image.DOFade(0.5f, 1f)
            .SetLoops(-1, LoopType.Yoyo);*/


    }
}
