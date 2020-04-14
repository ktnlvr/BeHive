using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    protected void OnEnable() => EventManager.BeehiveInit.AddListener(AssignToBeehive);
    protected void OnDisable() => EventManager.BeehiveInit.RemoveListener(AssignToBeehive);

    protected void AssignToBeehive(Hive hive)
    {
        hive.AssingFlowers(this);
    }
}
