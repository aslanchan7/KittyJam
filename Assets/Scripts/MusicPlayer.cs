using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public AudioResource Music;
    [HideInInspector] public AudioSource AudioSource;

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.resource = Music;
    }

    void Update()
    {
        GameManager.Instance.SongTimePositionMs = AudioSource.time * 1000; // AudioSource.time is in seconds
    }
}
