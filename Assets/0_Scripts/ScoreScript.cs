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
        score = score - 1;
        GetComponent<Text>().text = "Score:" + score.ToString();
    }
}