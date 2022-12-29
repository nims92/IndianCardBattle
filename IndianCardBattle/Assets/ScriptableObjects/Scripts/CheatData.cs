using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheatData", menuName = "Scriptable Objects/Cheat Data", order = 1)]
public class CheatData : ScriptableObject
{
    public List<LocationID> locationSpawnList;
}
