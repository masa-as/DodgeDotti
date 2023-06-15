using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip beatclip;
    public enum Note
    {
        //�S����, 2������, ..., 16������
        WholeNote = 1,
        HalfNote = 2,
        QuarterNote = 4,
        EighthNote = 8,
        SixteethNote = 16
    }
    public Note note;

    public float bpm;
    public float note_interval;
    private bool play_beat = true;  //�m�F�p
    private float beat_interval;
    private float beat_timer;

    private void Awake()
    {
        beat_interval = 60.0f / bpm;  // �b�P�ʕϊ�
        note_interval = beat_interval / ((float)note / 4.0f); // �m�[�c�̃^�C�~���O����
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
            if (play_beat)
            {
                audioSource.PlayOneShot(beatclip);
            }
            
        }
    }

}
