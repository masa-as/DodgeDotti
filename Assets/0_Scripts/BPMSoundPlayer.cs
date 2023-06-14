using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public float bpm;
    private float beat_interval;
    private float beat_timer;

    private void Start()
    {
        beat_interval = 60.0f / bpm; // •b’PˆÊ•ÏŠ·
        beat_timer = 0.0f;
    }

    private void FixedUpdate()
    {
        beat_timer += Time.fixedDeltaTime;

        if (beat_timer >= beat_interval)
        {
            beat_timer -= beat_interval;
            audioSource.PlayOneShot(clip);
        }
    }

}
