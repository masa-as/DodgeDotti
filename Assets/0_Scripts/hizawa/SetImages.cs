
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImages : MonoBehaviour
{

    public Image image;
    //public int Score;
    public Sprite[] sprites;
    private int _score;

    public GameObject scoreManager;
    ScoreScript scoreScript;
    [SerializeField] private int DefaultScore = 1000;

    // Use this for initialization


    public GameObject _particlePref1;
    private GameObject _particleObj1;
    public GameObject _particlePref2;
    private GameObject _particleObj2;
    public GameObject _particlePref3;
    private GameObject _particleObj3;
    public GameObject _particlePref4;
    private GameObject _particleObj4;

    private void Start()
    {
        // scoreManager = GameObject.Find("ScoreManager");
        // scoreScript = scoreManager.GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    public void Display()
    {

        Vector3 EffectPosition = new Vector3(0, (float)0.8, 0);


        // scoreÇ≈èÍçáÇÌÇØ
        //TODO ScoreÇÃéÊìæ
        _score = ScoreScript.getScore();
        // _score = DefaultScore;


        //Todo forÇ≈è»ó™
        if (_score <= 400)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[0];
            _particlePref1 = Instantiate(_particlePref1);
            _particlePref1.transform.position = EffectPosition;
        }
        else if (_score <= 600)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[1];
            _particlePref1 = Instantiate(_particlePref1);
            _particlePref1.transform.position = EffectPosition;
            _particlePref2 = Instantiate(_particlePref2);
            _particlePref2.transform.position = EffectPosition;
        }
        else if (_score <= 800)
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[2];
            _particlePref1 = Instantiate(_particlePref1);
            _particlePref1.transform.position = EffectPosition;
            _particlePref2 = Instantiate(_particlePref2);
            _particlePref2.transform.position = EffectPosition;
            _particlePref3 = Instantiate(_particlePref3);
            _particlePref3.transform.position = EffectPosition;
        }
        else
        {
            image = this.GetComponent<Image>();
            image.sprite = sprites[3];
            _particlePref1 = Instantiate(_particlePref1);
            _particlePref1.transform.position = EffectPosition;
            _particlePref2 = Instantiate(_particlePref2);
            _particlePref2.transform.position = EffectPosition;
            _particlePref3 = Instantiate(_particlePref3);
            _particlePref3.transform.position = EffectPosition;
            _particlePref4 = Instantiate(_particlePref4);
            _particlePref4.transform.position = EffectPosition;
        }
    }
}