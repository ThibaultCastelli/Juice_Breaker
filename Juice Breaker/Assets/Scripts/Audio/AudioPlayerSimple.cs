using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Default Audio Player", menuName = "Audio/AudioPlayer")]
public class AudioPlayerSimple : IAudioPlayer
{
    #region Variables
    [SerializeField] [TextArea] string description;

    [Header("COMPONENTS")]
    [SerializeField] List<AudioClip> audios = new List<AudioClip>();
    [SerializeField] AudioMixerGroup mixerGroup;
    [Space]

    [Header("INFOS")]
    [SerializeField] [Range(0f, 1f)] float volume = 1f;
    [SerializeField] [Range(0f, 1f)] float pitch = 1f;
    [SerializeField] [Range(-1f, 1f)] float pan = 0f;

    [SerializeField] bool loop;
    [SerializeField] bool playOnAwake;

    public override bool PlayOnAwake { get { return playOnAwake; } }
    public override AudioSource source { get; set; }
    #endregion

    #region Functions
    public override void Play()
    {
        SetAudioSource();
        source.Play();
    }

    public override void PlayDelayed(float delay)
    {
        SetAudioSource();
        source.PlayDelayed(delay);
    }

    public override void Stop()
    {
        if (source.clip != null)
            source.Stop();
    }

    public override void Replay()
    {
        if (source.clip != null)
            source.Play();
    }

    public override void Pause()
    {
        if (source.clip != null)
            source.Pause();
    }

    public override void Unpause()
    {
        if (source.clip != null)
            source.UnPause();
    }

    public override void Mute()
    {
        if (source.clip != null)
            source.mute = true;
    }

    public override void Unmute()
    {
        if (source.clip != null)
            source.mute = false;
    }

    protected override void SetAudioSource()
    {
        source.clip = audios[Random.Range(0, audios.Count)];
        source.outputAudioMixerGroup = mixerGroup;
        source.volume = volume;
        source.pitch = pitch;
        source.panStereo = pan;
        source.loop = loop;
    }

    public override void PreviewPlay(AudioSource source)
    {
        source.clip = audios[Random.Range(0, audios.Count)];
        source.volume = volume;
        source.pitch = pitch;
        source.panStereo = pan;

        source.Play();
    }

    public override void StopPreview(AudioSource source)
    {
        source.Stop();
    }
    #endregion
}
