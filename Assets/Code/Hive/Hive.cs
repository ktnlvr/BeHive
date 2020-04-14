using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public List<Flower> flowers;

    private void Start()
    {
        EventManager.BeehiveInit.Invoke(this);
    }

    public void AssingFlowers(Flower flower)
    {
        flowers.Add(flower);
    }
}
