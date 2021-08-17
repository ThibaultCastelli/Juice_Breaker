using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] Event eventToListen;
    [SerializeField] UnityEvent response;

    private void OnEnable() => eventToListen.AddEvent(this);

    private void OnDisable() => eventToListen.RemoveEvent(this);

    public void OnRaise() => response?.Invoke();
}
