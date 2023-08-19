using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    private Dictionary<string, UnityEvent> eventDictionary;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();

                if (instance == null)
                {
                    GameObject manager = new GameObject("EventManager");
                    instance = manager.AddComponent<EventManager>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        eventDictionary = new Dictionary<string, UnityEvent>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (instance == null) return;
        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
