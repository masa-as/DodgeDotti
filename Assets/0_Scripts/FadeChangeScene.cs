using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class FadeChangeScene : MonoBehaviour
{
    //name of the scene you want to load
    public string sceneName;
    public Color loadToColor = Color.white;
    public int SecToTransition;

    GameObject Score;
    ScoreScript scoreScript;

    private async void Start()
    {
        await GoToNextScene();
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "Main2")
        {
            Score = GameObject.Find("Score");
            scoreScript = Score.GetComponent<ScoreScript>();
        }
    }

    private async UniTask GoToNextScene()
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        await UniTask.WhenAll(
            UniTask.Delay(SecToTransition * 1000),
            UniTask.WaitUntil(() => scene.progress >= 0.9f)
        );
        scene.allowSceneActivation = true;
        GoFade();
    }

    public void GoFade()
    {
        Initiate.Fade(sceneName, loadToColor, 1.0f);
    }
}
