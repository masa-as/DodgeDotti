using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatManager : MonoBehaviour
{

    public AudioSource audioSource;
    // public AudioClip beatclip;
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
    private bool play_beat = true;  //�m�F�p
    private float beat_interval;
    private float beat_timer;
    public Dictionary<Note, float> note2interval = new Dictionary<Note, float>();

    private void Awake()
    {
        beat_interval = 60.0f / bpm;  // �b�P�ʕϊ�
        foreach (Note _note in System.Enum.GetValues(typeof(Note)))
        {
            note2interval[_note] = beat_interval / ((float)_note / 4.0f);
        }
    }

    private void Start()
    {
        beat_timer = 0.0f;
        note = Note.HalfNote;
        if (SceneManager.GetActiveScene().name == "Main")
        {
            StartCoroutine("ChangeNote1");
            StartCoroutine("ChangeNote2");
            StartCoroutine("ChangeNote3");
            StartCoroutine("ChangeNote4");
            StartCoroutine("ChangeNote5");
            StartCoroutine("ChangeNote6");
        }
        else if (SceneManager.GetActiveScene().name == "Main2")
        {
            StartCoroutine("ChangeNote2_1");
            StartCoroutine("ChangeNote2_2");
            StartCoroutine("ChangeNote2_3");
            StartCoroutine("ChangeNote2_4");
            StartCoroutine("ChangeNote2_5");
            StartCoroutine("ChangeNote2_6");

        }
    }

    IEnumerator ChangeNote1()
    {
        yield return new WaitForSeconds(16);
        note = Note.QuarterNote;
    }

    IEnumerator ChangeNote2()
    {
        yield return new WaitForSeconds(32);
        note = Note.EighthNote;
    }
    IEnumerator ChangeNote3()
    {
        yield return new WaitForSeconds(40);
        note = Note.QuarterNote;
    }
    IEnumerator ChangeNote4()
    {
        yield return new WaitForSeconds(44);
        note = Note.HalfNote;
    }
    IEnumerator ChangeNote5()
    {
        yield return new WaitForSeconds(50);
        note = Note.QuarterNote;
    }
    IEnumerator ChangeNote6()
    {
        yield return new WaitForSeconds(58);
        note = Note.EighthNote;
    }

    IEnumerator ChangeNote2_1()
    {
        yield return new WaitForSeconds(17);
        note = Note.QuarterNote;
    }

    IEnumerator ChangeNote2_2()
    {
        yield return new WaitForSeconds(32);
        note = Note.EighthNote;
    }
    IEnumerator ChangeNote2_3()
    {
        yield return new WaitForSeconds(48);
        note = Note.QuarterNote;
    }
    IEnumerator ChangeNote2_4()
    {
        yield return new WaitForSeconds(60);
        note = Note.HalfNote;
    }
    IEnumerator ChangeNote2_5()
    {
        yield return new WaitForSeconds(78);
        note = Note.QuarterNote;
    }
    IEnumerator ChangeNote2_6()
    {
        yield return new WaitForSeconds(85);
        note = Note.HalfNote;
    }

    IEnumerator ChangeNote2_7()
    {
        yield return new WaitForSeconds(92);
        note = Note.QuarterNote;
    }
    IEnumerator ChangeNote2_8()
    {
        yield return new WaitForSeconds(108);
        note = Note.EighthNote;
    }
    IEnumerator ChangeNote2_9()
    {
        yield return new WaitForSeconds(124);
        note = Note.HalfNote;
    }
    IEnumerator ChangeNote2_10()
    {
        yield return new WaitForSeconds(139);
        note = Note.QuarterNote;
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
