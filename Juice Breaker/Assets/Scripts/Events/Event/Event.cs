using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Event", menuName = "Event")]
public class Event : ScriptableObject
{
    List<EventListener> eventListeners = new List<EventListener>();

    public void RaiseEvent()
    {
        foreach (var eventListener in eventListeners)
            eventListener.OnRaise();
    }

    public void AddEvent(EventListener newEvent)
    {
        if (eventListeners.Contains(newEvent))
            return;

        eventListeners.Add(newEvent);
    }

    public void RemoveEvent(EventListener eventToRemove)
    {
        if (!eventListeners.Contains(eventToRemove))
            return;

        eventListeners.Remove(eventToRemove);
    }
}
