using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace Title
{
    public class DisplayTitle : MonoBehaviour
    {
        private Image _image;
        private Sprite[] sprites;

        public void DisplayImageSample()
        {
            //�����ɏ���������
            //�T���v���R�[�h�����Ă����܂��B
            _image = this.GetComponent<Image>();
            _image.sprite = sprites[0];
        }
    }
}