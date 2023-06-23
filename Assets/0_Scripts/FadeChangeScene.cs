using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeChangeScene : MonoBehaviour
{
    //name of the scene you want to load
    public string scene;
    public Color loadToColor = Color.white;
    public int SecToTransition;

    GameObject Score;
    ScoreScript scoreScript;

    private void Start()
    {
        StartCoroutine("GoToNextScene");
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Main2_BlueChip")
        {
            Score = GameObject.Find("Score");
            scoreScript = Score.GetComponent<ScoreScript>();
        }
    }

    IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(SecToTransition);

        // if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Main2_BlueChip")
        // {
        //     scoreScript.SaveScore();
        // }
        GoFade();
    }

    public void GoFade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         GoFade();
    //     }
    // }

}
