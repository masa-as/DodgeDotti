using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    public AudioSource audioSource;
    // public AudioClip beatclip;
    public enum Note
    {
        //全音符, 2分音符, ..., 16分音符
        WholeNote = 1,
        HalfNote = 2,
        QuarterNote = 4,
        EighthNote = 8,
        SixteethNote = 16
    }
    public Note note;

    public float bpm;
    private bool play_beat = true;  //確認用
    private float beat_interval;
    private float beat_timer;
    public Dictionary<Note, float> note2interval = new Dictionary<Note, float>();

    private void Awake()
    {
        beat_interval = 60.0f / bpm;  // 秒単位変換
        foreach (Note _note in System.Enum.GetValues(typeof(Note)))
        {
            note2interval[_note] = beat_interval / ((float)_note / 4.0f);
        }
    }

    private void Start()
    {
        beat_timer = 0.0f;
    }

    private void FixedUpdate()
    {
        beat_timer += Time.fixedDeltaTime;

        if (beat_timer >= beat_interval)
        {
            beat_timer -= beat_interval;
            // if (play_beat)
            // {
            //     audioSource.PlayOneShot(beatclip);
            // }

        }
    }

}
