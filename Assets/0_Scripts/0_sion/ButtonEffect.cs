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

        //�g��k��
        transform.DOScale(new Vector3(1.01f, 1.01f, 1.01f), 0.5f)
            .SetLoops(-1, LoopType.Yoyo);
        //�t�F�[�h�Ō���
       /*var image = GetComponent<Image>();
        image.DOFade(0.5f, 1f)
            .SetLoops(-1, LoopType.Yoyo);*/


    }
}
