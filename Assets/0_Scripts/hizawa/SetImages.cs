
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImages : MonoBehaviour
{

    public Image image;
    public int Score;
    public Sprite [] sprites;


    // Use this for initialization


    public GameObject _particlePrefGood;
    private GameObject _particleObjGood;
    public GameObject _particlePrefPerfect;
    private GameObject _particleObjPerfect;



    // Update is called once per frame
    public void Display()
    {
        // scoreÇ≈èÍçáÇÌÇØ
        if (Score <= 400)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[0];
            _particlePrefGood = Instantiate(_particlePrefGood);
            _particlePrefGood.transform.position = new Vector3(0,(float)0.7,0);
        }
        else if(Score <= 600)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[1];
            _particlePrefGood = Instantiate(_particlePrefGood);
            _particlePrefGood.transform.position = new Vector3(0, (float)0.7, 0);
            _particlePrefGood = Instantiate(_particlePrefGood);
            _particlePrefGood.transform.position = new Vector3(0, (float)0.7, 0);
        }
        else if (Score <= 800)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[2];
            _particlePrefPerfect = Instantiate(_particlePrefPerfect);
            _particlePrefPerfect.transform.position = new Vector3(0, (float)0.7, 0);
            _particlePrefPerfect = Instantiate(_particlePrefPerfect);
            _particlePrefPerfect.transform.position = new Vector3(0, (float)0.7, 0);
        }
        else
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[3];
            _particlePrefGood = Instantiate(_particlePrefGood);
            _particlePrefGood.transform.position = new Vector3(0, (float)0.7, 0);
            _particlePrefPerfect = Instantiate(_particlePrefPerfect);
            _particlePrefPerfect.transform.position = new Vector3(0, (float)0.7, 0);
        }
    }
}