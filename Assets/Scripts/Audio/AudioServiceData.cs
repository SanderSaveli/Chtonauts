using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct MusicPair
{
    public string name;
    public AudioClip clip;
}

[CreateAssetMenu(fileName = "AudioData", menuName = "AudioService/new AudioService Data")]
[Serializable]
public class AudioServiceData : ScriptableObject
{
    [Header("Sounds")]
    [SerializeField] 
    public List<MusicPair> sounds;

    [Space]

    [Header("Audio")]
    [SerializeField]
    public List<MusicPair> audios;

    public MusicPair GetSoundPairByName(string name)
    {
        return sounds.FirstOrDefault(audioPair => audioPair.name == name);
    }
    public MusicPair GetAudioPairByName(string name)
    {
        return audios.FirstOrDefault(audioPair => audioPair.name == name);
    }
}
