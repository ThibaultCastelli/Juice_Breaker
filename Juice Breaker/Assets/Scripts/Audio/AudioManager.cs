using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<IAudioPlayer> clips = new List<IAudioPlayer>();

    static Dictionary<string, IAudioPlayer> dicClips = new Dictionary<string, IAudioPlayer>();

    static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        // Don't destroy on load and check if there is only 1 audio manager, otherwise destroy the second
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        // Fill the dictionary
        foreach (var clip in clips)
        {
            dicClips.Add(clip.name, clip);

            clip.source = gameObject.AddComponent<AudioSource>();

            if (clip.PlayOnAwake)
                clip.Play();
        }
    }

    public static IAudioPlayer GetAudioPlayer(string name)
    {
        IAudioPlayer audioPlayer;

        if (dicClips.TryGetValue(name, out audioPlayer))
            return audioPlayer;

        return null;
    }
}
