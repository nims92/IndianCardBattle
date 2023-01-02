using UnityEngine;

public class CardHorizontalLayoutHandler
{
    private int currentCardCount;
    private Transform selfTransform;
    private float horizontalOffset;
    private Vector3 startPosition;
    private float cardWidth;
    
    public CardHorizontalLayoutHandler(Transform selfTransform,float xOffset,float startPosition)
    {
        this.selfTransform = selfTransform;
        horizontalOffset = xOffset;
        this.startPosition = new Vector3(startPosition,0,0);
    }
    
    public Vector3 GetCardPositionForIndex(int index)
    {
        return startPosition + new Vector3(horizontalOffset * index,0,0);
    }
}
