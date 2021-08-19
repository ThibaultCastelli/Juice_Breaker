using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IAudioPlayer), true)]
public class AudioPlayerEditor : Editor
{
    AudioSource _previewer;

    private void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio Preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(_previewer.gameObject);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        IAudioPlayer audioEvent = (IAudioPlayer)target;

        if (GUILayout.Button("Preview"))
            audioEvent.PreviewPlay(_previewer);

        if (GUILayout.Button("Stop"))
            audioEvent.StopPreview(_previewer);
    }
}
