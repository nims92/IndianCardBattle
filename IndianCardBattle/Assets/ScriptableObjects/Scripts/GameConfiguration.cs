using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfiguration", menuName = "Scriptable Objects/Game Configuration", order = 1)]

public class GameConfiguration : ScriptableObject
{
    public int numberOfTurns;
    public int energyCostIncrementWithEachTurn;
    public int cardDeckSize;
    public int maxCardInHand;
}
