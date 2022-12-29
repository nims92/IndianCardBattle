using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAbilityDatabase", menuName = "Scriptable Objects/Card Ability Database", order = 1)]

public class CardAbilityDatabase : ScriptableObject
{
    public List<LocationAbility> listOfCardAbilities;
}
