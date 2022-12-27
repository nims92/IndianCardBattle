﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public delegate void Listener(params object[] args);
public class CustomEventManager
{
    public enum CustomEvents
    {
        Test1,
        Test2
    }

    private static CustomEventManager instance;
    private Dictionary<CustomEvents, List<Listener>> eventDictionary;

    public static CustomEventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CustomEventManager();
                instance.Init();
            }
            return instance;
        }
    }

    void Init()
    {
        eventDictionary = new Dictionary<CustomEvents, List<Listener>>();
    }

    public void AddListener(CustomEvents e, Listener listener)
    {

        if (eventDictionary.ContainsKey(e))
            eventDictionary[e].Add(listener);
        else
        {
            List<Listener> listenersList = new List<Listener>();
            listenersList.Add(listener);
            eventDictionary.Add(e, listenersList);
        }
    }

    public void RemoveAllListener(CustomEvents e)
    {
        List<Listener> l = null;
        if (eventDictionary.TryGetValue(e, out l))
        {
            l.Clear();
            eventDictionary.Remove(e);
        }
    }

    /// <summary>
    /// Remove the specific listener from the list of listeners
    /// </summary>
    /// <param name="e"></param>
    /// <param name="listener"></param>
    public void RemoveListener(CustomEvents e, Listener listener)
    {
        if (eventDictionary.ContainsKey(e))
        {
            eventDictionary[e].Remove(listener);
            // if there are no listeners to this event, remove it from the dictionary
            if (eventDictionary[e].Count == 0)
                eventDictionary.Remove(e);
        }
    }

    public void Invoke(CustomEvents e, params object[] args)
    {
        if (eventDictionary.ContainsKey(e))
        {
            int listenersCount = eventDictionary[e].Count;
            for (int i = 0; i < listenersCount; i++)
                eventDictionary[e][i](args);
        }
    }
}