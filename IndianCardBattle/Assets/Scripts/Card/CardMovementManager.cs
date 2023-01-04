using System;
using DG.Tweening;
using UnityEngine;

public class CardMovementManager : ICardMovementManager
{
    private readonly Transform cardTransform;

    public CardMovementManager(Transform cardTransform)
    {
        this.cardTransform = cardTransform;
    }

    public void MoveToPosition(Vector3 targetPosition,float movementTime)
    {
        cardTransform.DOMove(targetPosition, movementTime);
    }
    
    public void MoveToLocalPosition(Vector3 targetPosition,float movementTime,Action callback = null)
    {
        cardTransform.DOLocalMove(targetPosition, movementTime)
            .OnComplete(()=> callback?.Invoke());
    }

    public void SnapToPosition(Vector3 targetPosition, float movementTime)
    {
        cardTransform.DOMove(targetPosition, 0.05f);
    }
    
    public void SnapToLocalPosition(Vector3 targetPosition,float movementTime)
    {
        cardTransform.DOLocalMove(targetPosition, 0.05f);
    }

    public void ChangeScaleTo(Vector3 newScale,float movementTime)
    {
        cardTransform.DOScale(newScale, movementTime);
    }

    public void RotateBy(float angle)
    {
        //TODO: implementation pending
    }

    public void ChangeParent(Transform newParentTransform)
    {
        cardTransform.SetParent(newParentTransform);
    }
}