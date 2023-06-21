
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImage : MonoBehaviour
{

    public Image image;
    private Sprite sprite;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Z ÉLÅ[Ç™âüÇ≥ÇÍÇΩéû
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sprite = Resources.Load<Sprite>("bag2");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}