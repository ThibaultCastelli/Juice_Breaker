using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListenerSave : MonoBehaviour
{
    [SerializeField] EventSave eventToListen;
    [SerializeField] UnityEvent<Save> response;

    public void OnRaise(Save save) => response?.Invoke(save);

    private void OnEnable() => eventToListen.AddListener(this);

    private void OnDisable() => eventToListen.RemoveListener(this);
}
