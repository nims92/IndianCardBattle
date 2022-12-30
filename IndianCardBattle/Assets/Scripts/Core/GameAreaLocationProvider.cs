using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaLocationProvider : MonoBehaviour
{
    [SerializeField] private Transform locationParent;
    [SerializeField] private Transform playerCardDeckParent;
    [SerializeField] private Transform playerCardHandParent;
    [SerializeField] private Transform opponentCardDeckParent;
    [SerializeField] private Transform opponentCardHandParent;

    public Transform LocationParent => locationParent;
    public Transform PlayerCardDeckParent => playerCardDeckParent;
    public Transform PlayerCardHandParent => playerCardHandParent;
    public Transform OpponentCardDeckParent => opponentCardDeckParent;
    public Transform OpponentCardHandParent => opponentCardHandParent;
}
