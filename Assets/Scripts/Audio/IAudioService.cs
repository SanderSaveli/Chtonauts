using UnityEngine;

public interface IAudioService
{
    public float AudioVolume { get;}
    public float SoundVolume { get;}
    public void PlayAudio(string name);
    public void PlaySound(string name);
    public void StopAudio();

    public void ChandeSoundVolume(float value);
    public void ChandeAudioVolume(float value);

    public void ChangeData(AudioServiceData data);
}
