using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationDatabase", menuName = "Scriptable Objects/Location Database", order = 1)]
public class LocationDatabase : ScriptableObject
{
    public List<LocationDataEntry> locationList;
}