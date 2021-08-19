using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Default Audio Player Random", menuName = "Audio/AudioPlayerRandom")]
public class AudioPlayerRandom : IAudioPlayer
{
    #region Variables
    [SerializeField] [TextArea] string description;

    [Header("COMPONENTS")]
    [SerializeField] List<AudioClip> audios = new List<AudioClip>();
    [SerializeField] AudioMixerGroup mixerGroup;
    [Space]

    [Header("INFOS")]
    [SerializeField] [Range(0f, 1f)] float minVolume = 1f;
    [SerializeField] [Range(0f, 1f)] float maxVolume = 1f;

    [SerializeField] [Range(0f, 2f)] float minPitch = 1f;
    [SerializeField] [Range(0f, 2f)] float maxPitch = 1f;

    [SerializeField] [Range(-1f, 1f)] float minPan = 0f;
    [SerializeField] [Range(-1f, 1f)] float maxPan = 0f;

    [SerializeField] bool loop;
    [SerializeField] bool playOnAwake;

    AudioClip _currentClip;
    float _currentVolume;
    float _currentPitch;
    float _currentPan;

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
        if (source == null)
            return; 

        source.clip = audios[Random.Range(0, audios.Count)];
        source.outputAudioMixerGroup = mixerGroup;
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.panStereo = Random.Range(minPan, maxPan);
        source.loop = loop;
    }

    public override void PreviewPlay(AudioSource source)
    {
        source.clip = audios[Random.Range(0, audios.Count)];
        source.volume = Random.Range(minVolume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.panStereo = Random.Range(minPan, maxPan);

        source.Play();
    }

    public override void StopPreview(AudioSource source)
    {
        source.Stop();
    }
    #endregion
}
