using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public float bpm;
    private float beatInterval;

    private void Start()
    {
        if (bpm >= 0){
            beatInterval = 60.0f / bpm; // �b�P�ʕϊ�
            StartCoroutine(PlayBeat()); // �R���[�`�����s
        }
    }

    private IEnumerator PlayBeat()
    {
        while (true)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(beatInterval); // beatInterval�b�҂�
        }
    }
}
