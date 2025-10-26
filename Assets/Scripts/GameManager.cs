using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float SongTimePositionMs;
    public Metronome metronome;
    public SpriteRenderer circle;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        metronome.OnEnterBeat += OnEnterBeat;
        metronome.OnExitBeat += OnExitBeat;
    }

    void OnDisable()
    {
        metronome.OnEnterBeat -= OnEnterBeat;
        metronome.OnExitBeat -= OnExitBeat;
    }

    void OnEnterBeat(int beat)
    {
        Debug.Log(beat);
        circle.color = Color.black;
    }

    void OnExitBeat(int beat)
    {
        Debug.Log(beat);
        circle.color = Color.white;
    }
}
