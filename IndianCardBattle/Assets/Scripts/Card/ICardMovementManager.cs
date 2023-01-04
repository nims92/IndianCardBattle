using System;
using UnityEngine;

public interface ICardMovementManager
{
    void MoveToPosition(Vector3 targetPosition,float movementTime);
    void MoveToLocalPosition(Vector3 targetPosition,float movementTime, Action callback = null);
    void SnapToPosition(Vector3 targetPosition,float movementTime);
    void SnapToLocalPosition(Vector3 targetPosition,float movementTime);
    void ChangeScaleTo(Vector3 newScale,float movementTime);
    void RotateBy(float angle);
    void ChangeParent(Transform newParentTransform);
}