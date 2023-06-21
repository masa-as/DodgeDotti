using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    private int score = 0;

    void Start()
    {
        GetComponent<Text>().text = "Score:" + score.ToString();
    }
    public void ReducePoint()
    {
        score = score - 5;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }
    public void AddPoint(int point)
    {
        score = score + point;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }

    public void SaveScore()
    {
        //EDÇ÷ÇÃÉVÅ[ÉìêÿÇËë÷Ç¶ëOÇ…åƒÇ‘
        PlayerPrefs.SetInt("Score", score);
    }

}