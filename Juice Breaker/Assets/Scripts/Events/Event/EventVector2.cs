using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Event Vector2", menuName = "EventVector2")]
public class EventVector2 : ScriptableObject
{
    List<EventListenerVector2> eventListeners = new List<EventListenerVector2>();

    public void RaiseEvent(Vector2 vector2)
    {
        foreach (var eventListener in eventListeners)
            eventListener.OnRaise(vector2);
    }

    public void AddEvent(EventListenerVector2 newEvent)
    {
        if (eventListeners.Contains(newEvent))
            return;

        eventListeners.Add(newEvent);
    }

    public void RemoveEvent(EventListenerVector2 eventToRemove)
    {
        if (!eventListeners.Contains(eventToRemove))
            return;

        eventListeners.Remove(eventToRemove);
    }
}
