using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static BeehiveInit BeehiveInit = new BeehiveInit();
}

public class BeehiveInit : UnityEvent<Hive> { }
