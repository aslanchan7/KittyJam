using System;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public float bpm;
    public event Action<int> OnBeat;
    public event Action<int> OnEnterBeat;
    public event Action<int> OnExitBeat;

    private float beatDurationMs;
    private int lastBeat;
    private float nextBeatPos;
    private int activeBeat;
    private float activeBeatStartPos, activeBeatEndPos;
    public float marginMs;

    void Awake()
    {
        beatDurationMs = 60 / bpm * 1000;
        lastBeat = 0;
        nextBeatPos = beatDurationMs;
        activeBeat = -1;
        activeBeatStartPos = nextBeatPos - marginMs;
        activeBeatEndPos = nextBeatPos + marginMs;
    }

    void Update()
    {
        float pos = GameManager.Instance.SongTimePositionMs;
        if (pos > nextBeatPos)
        {
            lastBeat++;
            OnBeat?.Invoke(lastBeat);
            nextBeatPos += beatDurationMs;
        }

        if (pos > activeBeatStartPos)
        {
            activeBeat = lastBeat + 1;
            OnEnterBeat?.Invoke(activeBeat);
            activeBeatStartPos += beatDurationMs;
        }

        if (pos > activeBeatEndPos)
        {
            OnExitBeat?.Invoke(activeBeat);
            activeBeatEndPos += beatDurationMs;
            activeBeat = -1;
        }
    }
}
