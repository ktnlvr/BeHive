using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Engine/Building", order = 0)]
public class Building : ScriptableObject
{
    public GameObject prefab;
    public Size size;
}
