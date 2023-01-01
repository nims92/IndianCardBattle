using System;
using UnityEngine;

public interface ICardMovementManager
{
    void MoveToPosition(Vector3 targetPosition);
    void MoveToLocalPosition(Vector3 targetPosition, Action callback);
    void ChangeScaleTo(Vector3 newScale);
    void RotateBy(float angle);
    void ChangeParent(Transform newParentTransform);
}