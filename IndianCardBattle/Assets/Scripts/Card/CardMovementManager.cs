using System;
using DG.Tweening;
using UnityEngine;

//TODO refactor this class
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
        cardTransform.DOMove(targetPosition, movementTime);
        //LeanTween.move(cardTransform.gameObject, targetPosition, movementTime);
    }
    
    public void MoveToLocalPosition(Vector3 targetPosition,Action callback)
    {
        cardTransform.DOLocalMove(targetPosition, movementTime)
            .OnComplete(()=> callback?.Invoke());
        //LeanTween.moveLocal(cardTransform.gameObject, targetPosition, movementTime)
          //  .setOnComplete(callback);
    }

    public void SnapToPosition(Vector3 targetPosition)
    {
        cardTransform.DOMove(targetPosition, 0.05f);
        //LeanTween.move(cardTransform.gameObject, targetPosition, 0.05f);
    }
    
    public void SnapToLocalPosition(Vector3 targetPosition)
    {
        cardTransform.DOLocalMove(targetPosition, 0.05f);
        //LeanTween.moveLocal(cardTransform.gameObject, targetPosition, 0.05f);
    }

    public void ChangeScaleTo(Vector3 newScale)
    {
        cardTransform.DOScale(newScale, movementTime);
        //LeanTween.scale(cardTransform.gameObject, newScale, movementTime);
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