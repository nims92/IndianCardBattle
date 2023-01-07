using System;
using System.Collections.Generic;
using UnityEngine;

public class LocationCardPlacement :MonoBehaviour, ILocationCardPlacement
{
    private List<Vector3> placements;
    private List<ICard> currentCards;
    private Transform selfTransform;

    [SerializeField] private GameObject areaHighlight;

    #region Monobehaviour

    private void OnEnable()
    {
        CustomEventManager.Instance.AddListener(InteractionEvents.CARD_TOUCH_START,EnableHightlight);
        CustomEventManager.Instance.AddListener(InteractionEvents.CARD_TOUCH_END,DisableHightlight);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.RemoveListener(InteractionEvents.CARD_TOUCH_START,EnableHightlight);
        CustomEventManager.Instance.RemoveListener(InteractionEvents.CARD_TOUCH_END,DisableHightlight);
    }

    #endregion
    
    
    public void Init(List<Vector3> placementPositions)
    {
        placements = placementPositions;
        currentCards = new List<ICard>();
        selfTransform = transform;
    }

    public bool IsPlacementAreaFull()
    {
        return placements.Count == currentCards.Count;
    }

    public Vector3 GetNextEmptyPosition()
    {
        if (IsPlacementAreaFull())
            return Vector3.zero;

        return placements[currentCards.Count];
    }

    public void AddCard(ICard card)
    {
        if (IsPlacementAreaFull())
            return;
        
        card.CardMovementManager.ChangeParent(selfTransform);
        card.CardMovementManager.MoveToLocalPosition(GetNextEmptyPosition(),GameData.Instance.AnimationData.cardNormalMovementTime);
        card.CardMovementManager.ChangeScaleTo(GameData.Instance.GameplayData.GetCardScaleAtLocation(),GameData.Instance.AnimationData.cardScaleAnimationTime);
        card.OnCardPlacedAtLocation();
        currentCards.Add(card);
    }
    public void RemoveCard(ICard card)
    {
        currentCards.Remove(card);
    }
    
    public void LockAllPlacedCards()
    {
        foreach (var card in currentCards)
        {
            card.SetCardLockedAtLocation();
        }
    }

    private void EnableHightlight(params object []args)
    {
        if(IsPlacementAreaFull())
            return;
        
        if(areaHighlight)
            areaHighlight.SetActive(true);
    }

    private void DisableHightlight(params object []args)
    {
        if(areaHighlight)
            areaHighlight.SetActive(false);
    }
}