
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImage : MonoBehaviour
{

    public Image image;
    public int Score;
    public Sprite [] sprites;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // scoreÇ≈èÍçáÇÌÇØ
        if (Score <= 200)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[0];
        }
        else if(Score <= 400)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[1];
        }
        else if (Score <= 800)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[2];
        }
        else
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[3];
        }
    }
}