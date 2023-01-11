using DG.Tweening;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CardHorizontalLayoutHandler
{
    private Transform selfTransform;
    private float horizontalOffset;
    private Vector3 startPosition;
    private Vector3 startPositionOfLayout;

    public CardHorizontalLayoutHandler(Transform selfTransform,float xOffset,float startPosition)
    {
        this.selfTransform = selfTransform;
        horizontalOffset = xOffset;
        this.startPosition = new Vector3(startPosition,0,0);
        startPositionOfLayout = selfTransform.position;
    }
    
    public Vector3 GetCardPositionForIndex(int index)
    {
        return startPosition + new Vector3(horizontalOffset * index,0,0);
    }

    public void UpdateLayout()
    {
        var childCount = selfTransform.childCount;
        var scale = GetScaleForHandParent(childCount);
        var centerPos = ((childCount-1) * horizontalOffset)/ 2f;
        
        //Update scale and position
        selfTransform.DOScale(new Vector3(scale, 1, scale), GameData.Instance.AnimationData.cardScaleAnimationTime);
        selfTransform.DOMoveX(-centerPos * scale, GameData.Instance.AnimationData.cardNormalMovementTime);
        //selfTransform.position = new Vector3(-centerPos * scale, startPositionOfLayout.y, startPositionOfLayout.z);
    }

    private float GetScaleForHandParent(int childCount)
    {
        switch (childCount)
        {
            case 6:
                return 0.9f;
            case 7:
                return 0.75f;
            default:
                return 1f;
        }
    }
}
