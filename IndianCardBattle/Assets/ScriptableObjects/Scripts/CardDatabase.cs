using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "Scriptable Objects/Card Database", order = 1)]
public class CardDatabase : ScriptableObject
{
    public List<Card> cardList;
}
