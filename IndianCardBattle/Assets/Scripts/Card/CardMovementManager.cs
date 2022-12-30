using System;
using UnityEngine;

public class CardMovementManager : ICardMovementManager
{
    private Transform cardTransform;
    private float movementTime = 1f;
    private ICardMovementManager cardMovementManagerImplementation;

    public CardMovementManager(Transform cardTransform)
    {
        this.cardTransform = cardTransform;
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        LeanTween.move(cardTransform.gameObject, targetPosition, movementTime);
    }
    
    public void MoveToLocalPosition(Vector3 targetPosition)
    {
        LeanTween.moveLocal(cardTransform.gameObject, targetPosition, movementTime);
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