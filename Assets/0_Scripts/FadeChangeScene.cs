using UnityEngine;
using System.Collections;

public class FadeChangeScene : MonoBehaviour
{
    //name of the scene you want to load
    public string scene;
    public Color loadToColor = Color.white;

    public void GoFade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GoFade();
        }
    }

}
