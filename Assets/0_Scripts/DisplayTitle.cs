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
            //ここに処理書いて
            //サンプルコード書いておきます。
            _image = this.GetComponent<Image>();
            _image.sprite = sprites[0];
        }
    }
}