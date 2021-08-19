using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class IAudioPlayer : ScriptableObject
{
    // Functions
    public abstract void Play();
    public abstract void PlayDelayed(float delay);
    public abstract void Stop();
    public abstract void Replay();
    public abstract void Pause();
    public abstract void Unpause();
    public abstract void Mute();
    public abstract void Unmute();
    protected abstract void SetAudioSource();

    // Editor Functions
    public abstract void PreviewPlay(AudioSource source);
    public abstract void StopPreview(AudioSource source);

    // Properties
    public abstract bool PlayOnAwake { get; }
    public abstract AudioSource source { get; set; }
}
