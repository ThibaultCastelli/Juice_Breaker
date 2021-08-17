using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Event Float", menuName = "EventFloat")]
public class EventFloat : ScriptableObject
{
    List<EventListenerFloat> eventListeners = new List<EventListenerFloat>();

    public void RaiseEvent(float x)
    {
        foreach (var eventListener in eventListeners)
            eventListener.OnRaise(x);
    }

    public void AddEvent(EventListenerFloat newEvent)
    {
        if (eventListeners.Contains(newEvent))
            return;

        eventListeners.Add(newEvent);
    }

    public void RemoveEvent(EventListenerFloat eventToRemove)
    {
        if (!eventListeners.Contains(eventToRemove))
            return;

        eventListeners.Remove(eventToRemove);
    }
}
