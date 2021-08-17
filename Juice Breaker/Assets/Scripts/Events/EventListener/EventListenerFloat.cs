using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListenerFloat : MonoBehaviour
{
    [SerializeField] EventFloat eventToListen;
    [SerializeField] UnityEvent<float> response;

    private void OnEnable() => eventToListen.AddEvent(this);

    private void OnDisable() => eventToListen.RemoveEvent(this);

    public void OnRaise(float x) => response?.Invoke(x);
}
