using System;
using System.Linq;
using UnityEngine;
using System.Collections;

public class VoiceController : MonoBehaviour
{

    [SerializeField] private string m_DeviceName;
    private AudioClip m_AudioClip;
    private int m_LastAudioPos;
    private float m_AudioLevel;
    private GameObject Player;

    private GameObject m_cube_right;

    private GameObject m_cube_left;
    private Vector3 playerTransform;


    [SerializeField, Range(10, 300)] private float m_AmpGain = 200;
    float tmp = 0;

    void Start()
    {
        string targetDevice = "";

        foreach (var device in Microphone.devices)
        {
            Debug.Log($"Device Name: {device}");
            if (device.Contains(m_DeviceName))
            {
                targetDevice = device;
            }
        }

        Debug.Log($"=== Device Set: {targetDevice} ===");
        m_AudioClip = Microphone.Start(targetDevice, true, 10, 48000);
        m_cube_left = (GameObject)Resources.Load("VoiceScaleLeft");
        m_cube_right = (GameObject)Resources.Load("VoiceScaleRight");
        Player = GameObject.Find("CenterEyeAnchor");

    }

    void Update()
    {
        float[] waveData = GetUpdatedAudio();
        if (waveData.Length == 0) return;

        m_AudioLevel = waveData.Average(Mathf.Abs);

        // TODO:リリース前に||は&&に変える
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            // o.oo5は超えてほしい
            if (0.005 < m_AudioLevel)
            {
                playerTransform = Player.transform.position;
                playerTransform.z += 1f;
                Instantiate(m_cube_left, playerTransform, Quaternion.Euler(0, 0, 90f));
                Instantiate(m_cube_right, playerTransform, Quaternion.Euler(0, 0, 90f));
            }
        }
    }

    private float[] GetUpdatedAudio()
    {

        int nowAudioPos = Microphone.GetPosition(null);// nullでデフォルトデバイス

        float[] waveData = Array.Empty<float>();

        if (m_LastAudioPos < nowAudioPos)
        {
            int audioCount = nowAudioPos - m_LastAudioPos;
            waveData = new float[audioCount];
            m_AudioClip.GetData(waveData, m_LastAudioPos);
        }
        else if (m_LastAudioPos > nowAudioPos)
        {
            int audioBuffer = m_AudioClip.samples * m_AudioClip.channels;
            int audioCount = audioBuffer - m_LastAudioPos;

            float[] wave1 = new float[audioCount];
            m_AudioClip.GetData(wave1, m_LastAudioPos);

            float[] wave2 = new float[nowAudioPos];
            if (nowAudioPos != 0)
            {
                m_AudioClip.GetData(wave2, 0);
            }

            waveData = new float[audioCount + nowAudioPos];
            wave1.CopyTo(waveData, 0);
            wave2.CopyTo(waveData, audioCount);
        }

        m_LastAudioPos = nowAudioPos;

        return waveData;
    }
}
