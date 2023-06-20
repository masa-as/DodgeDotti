using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreCountText;
    private int _score;
    public float scorecount = 0.0f;
    public float display_time_sec;
    [SerializeField] private int DefaultScore = 1000;
    public GameObject Score;
    private float displayInterval;
    public enum EDNumber
    {
        TochouMae,
        TochouUe
    }
    public EDNumber num;
    // Start is called before the first frame update
    void Start()
    {
        // ToDo: ED�V�[���؂�ւ��O�ɁAPlayerPrefs.SetInt("Score", DefaultScore)������
        _score = PlayerPrefs.GetInt("Score", DefaultScore);
        if (num == EDNumber.TochouMae)
        {
            Score.GetComponent<Text>().text = "Score:" + _score.ToString();
        }else if (num == EDNumber.TochouUe)
        {
            displayInterval = (float)_score / display_time_sec * 0.1f; //0.1�b�����ɉ�ʂɂ͕\��
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
    }
}
