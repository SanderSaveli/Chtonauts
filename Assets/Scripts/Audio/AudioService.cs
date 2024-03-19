using UnityEngine;

public class AudioService : IAudioService
{
    public float AudioVolume { get; private set; }

    public float SoundVolume { get; private set; }
    private AudioServiceData _data;
    private AudioSource _source;
    public AudioService(AudioServiceData data)
    {
        _data = data;
        _source = new GameObject("[AudioService]").AddComponent<AudioSource>();
    }

    public void ChandeAudioVolume(float value)
    {
        AudioVolume = value;
        _source.volume = AudioVolume;
    }

    public void ChandeSoundVolume(float value)
    {
        SoundVolume = value;
    }

    public void PlayAudio(string name)
    {
        MusicPair pair = _data.GetAudioPairByName(name);
        if (pair.clip == null)
            return;
        _source.Stop();
        _source.clip = pair.clip;
        _source.Play();
    }

    public void PlaySound(string name)
    {
        MusicPair pair = _data.GetSoundPairByName(name);
        if (pair.clip == null)
            return;
        _source.PlayOneShot(pair.clip, SoundVolume);
    }

    public void StopAudio()
    {
        _source.Stop();
    }

    public void ChangeData(AudioServiceData data)
    {
        if (data == null)
            return;
        _data = data;
    }
}
