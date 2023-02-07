using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;

    public AudioSource CurrentMusic { get; private set; }

    private void Awake()
    {
        foreach (var audioSource in _audioSources)
            audioSource.gameObject.SetActive(false);

        CurrentMusic = _audioSources[Random.Range(0, _audioSources.Length)];
    }
}
