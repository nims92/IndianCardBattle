using UnityEngine;

public enum PlayerInputType
{
    Human = 0,
    AI = 1,
    Photon = 2
}

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Scriptable Objects/Player Configuration", order = 1)]
public class PlayerConfiguration : ScriptableObject
{
    public string name;
    public PlayerInputType playerInputType;
    public Deck playerDeck;
}