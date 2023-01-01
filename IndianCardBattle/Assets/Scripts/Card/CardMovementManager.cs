using System;
using UnityEngine;

public class CardMovementManager : ICardMovementManager
{
    private Transform cardTransform;
    private float movementTime = 0.25f;
    private ICardMovementManager cardMovementManagerImplementation;

    public CardMovementManager(Transform cardTransform)
    {
        this.cardTransform = cardTransform;
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        LeanTween.move(cardTransform.gameObject, targetPosition, movementTime);
    }
    
    public void MoveToLocalPosition(Vector3 targetPosition,Action callback)
    {
        LeanTween.moveLocal(cardTransform.gameObject, targetPosition, movementTime)
            .setOnComplete(callback);
    }
    
    public void ChangeScaleTo(Vector3 newScale)
    {
        LeanTween.scale(cardTransform.gameObject, newScale, movementTime);
    }

    public void RotateBy(float angle)
    {
        //LeanTween.rotateAroundLocal()
    }

    public void ChangeParent(Transform newParentTransform)
    {
        cardTransform.SetParent(newParentTransform);
    }
}