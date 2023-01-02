using System;
using UnityEngine;

public interface ICardMovementManager
{
    void MoveToPosition(Vector3 targetPosition);
    void MoveToLocalPosition(Vector3 targetPosition, Action callback);
    void SnapToPosition(Vector3 targetPosition);
    void SnapToLocalPosition(Vector3 targetPosition);
    void ChangeScaleTo(Vector3 newScale);
    void RotateBy(float angle);
    void ChangeParent(Transform newParentTransform);
}