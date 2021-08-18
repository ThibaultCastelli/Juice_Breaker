using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Event Save", menuName = "EventSave")]
public class EventSave : ScriptableObject
{
    List<EventListenerSave> eventListeners = new List<EventListenerSave>();

    public void RaiseEvent(Save save)
    {
        foreach (var eventListerner in eventListeners)
            eventListerner.OnRaise(save);
    }

    public void AddListener(EventListenerSave newListener)
    {
        if (eventListeners.Contains(newListener))
            return;

        eventListeners.Add(newListener);
    }

    public void RemoveListener(EventListenerSave listenerToRemove)
    {
        if (!eventListeners.Contains(listenerToRemove))
            return;

        eventListeners.Remove(listenerToRemove);
    }
}
