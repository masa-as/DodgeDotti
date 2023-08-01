using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static int score;

    private void Awake()
    {
        score = getScore();
    }
    void Start()
    {
        // Debug.Log("load");
        // PlayerPrefs.GetInt("Score", score);
        GetComponent<Text>().text = "Score:" + score.ToString();
    }
    public void ReducePoint()
    {
        Debug.Log("reduce");
        score = score - 14;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }
    public void AddPoint(int point)
    {
        score = score + point;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }

    public static int getScore()
    {
        return score;
    }
}