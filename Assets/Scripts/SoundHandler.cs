using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioSource[] audios;
    private float[] times;
    public int curr;
    public const int MAIN = 0;
    public const int ELEVATOR = 1;

    void Start()
    {
        audios[MAIN].Play();
        curr = MAIN;
        times = new float[audios.Length];
    }

    public void play(int idx)
    {
        times[curr] = audios[curr].time;
        audios[curr].Stop();
        curr = idx;
        Debug.Log(times[0]+", "+times[1]);
        audios[curr].SetScheduledStartTime(times[curr]);
        audios[curr].Play();
    }
}
