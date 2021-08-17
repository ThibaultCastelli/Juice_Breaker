using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListenerVector2 : MonoBehaviour
{
    [SerializeField] EventVector2 eventToListen;
    [SerializeField] UnityEvent<Vector2> response;

    private void OnEnable() => eventToListen.AddEvent(this);

    private void OnDisable() => eventToListen.RemoveEvent(this);

    public void OnRaise(Vector2 vector2) => response?.Invoke(vector2);
}
