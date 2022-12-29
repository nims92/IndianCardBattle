using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationAbilityDatabase", menuName = "Scriptable Objects/Location Ability Database", order = 1)]
public class LocationAbilityDatabase : ScriptableObject
{
    public List<LocationAbilityDataEntry> listOfLocationAbilities;
}