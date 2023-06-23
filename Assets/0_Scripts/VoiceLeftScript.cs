using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class VoiceLeftScript : MonoBehaviour
{

    public int voice_left = 3;

    void Start()
    {
        GetComponent<Text>().text = "voice_left:ttt";
    }

    private void Update()
    {
        if (voice_left == 3)
        {
            GetComponent<Text>().text = "voice:ttt";
        }
        else if (voice_left == 2)
        {
            GetComponent<Text>().text = "voice:tt";
        }
        else if (voice_left == 1)
        {
            GetComponent<Text>().text = "voice:t";
        }
        else if (voice_left == 0)
        {
            GetComponent<Text>().text = "voice:";
        }
    }
    public void VoiceUse()
    {
        voice_left = voice_left - 1;
    }
}