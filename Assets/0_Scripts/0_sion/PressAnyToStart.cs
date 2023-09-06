using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class PressAnyToStart : MonoBehaviour
{
    //name of the scene you want to load
    public string sceneName;
    public Color loadToColor = Color.white;
    //public int SecToTransition;
    private bool isStarted = false;

    
    private async void Start()
    {
        await GoToNextScene();

    }

    private void Update()
    {
        StartOpening();
    }

    private async UniTask GoToNextScene()
    {
        //Wait Until the Trigger is pulled
        await UniTask.WaitUntil(() => isStarted);

        //await UniTask.Delay(SecToTransition * 1000);
        GoFade();
    }

    public void GoFade()
    {
        // canvasGroup.DOFade(1.0f, 1.0f);
        Initiate.Fade(sceneName, loadToColor, 1.0f);
    }

    public void StartOpening()
    {
        Debug.Log("StartOpening");
        if (OVRInput.GetDown(OVRInput.Button.Any)){
            isStarted = true;
        }
            
    }

}
