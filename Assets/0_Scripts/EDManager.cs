using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreCountText;
    public float scorecount = 0.0f;
    public float display_time_sec;
    public GameObject Score, _Image,
        //
        _replay;

    [SerializeField] private int DefaultScore = 1000;
    [SerializeField] private float offset = 2.0f; // スコア計算終了後からoffset秒後にイベント起こす

    private float displayInterval;
    private int _score;


    public enum EDNumber
    {
        TochouMae,
        TochouUe
    }
    public EDNumber num;
    // Start is called before the first frame update
    void Start()
    {
        _Image.gameObject.SetActive(false);
        //
        _replay.gameObject.SetActive(false);
        //
        _score = ScoreScript.getScore();

        if (num == EDNumber.TochouMae)
        {
            Score.GetComponent<Text>().text = "Score:" + _score.ToString();
        }
        else if (num == EDNumber.TochouUe)
        {
            displayInterval = (float)_score / display_time_sec * 0.1f; //0.1秒おきに画面には表示
            scoreCountText.text = "Score: " + ((int)scorecount).ToString();
            StartCoroutine(IncreaseScore());
        }
    }
    IEnumerator IncreaseScore()
    {
        while (scorecount < _score)
        {
            scorecount += displayInterval;
            scoreCountText.text = "Score: " + ((int)scorecount).ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(offset);
        _Image.gameObject.SetActive(true);
        //
        _replay.gameObject.SetActive(true);
        //
        _Image.GetComponent<SetImages>().Display();
    }



}
