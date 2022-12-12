using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    private string playerName;
    private int playerIndex;

    public void InitPlayerProfile(string playerName, int playerIndex)
    {
        this.playerName = playerName;
        this.playerIndex = playerIndex;
    }
}
