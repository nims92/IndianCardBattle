using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    protected Player player;
    private Camera camera;
    private ICard currentClickedCard;
    private Vector3 cardStartPosition;

    public LayerMask cardLayerMask;
    public LayerMask locationLayerMask;
    public LayerMask cardMovementLayerMask;
    
    
    public bool InteractionEnabled { get; set; }
    
    #region MonoBehaviour
    
    void Update()
    {
        if(InteractionEnabled)
            InputUpdate();
    }

    #endregion

    public virtual void InitialSetup(Player player)
    {
        this.player = player;
        camera = Camera.main;
    }

    public virtual void InputUpdate() { }

    public void OnTouchDown(Vector3 inputPosition)
    {
        Ray ray = camera.ScreenPointToRay(inputPosition);
        
        //Check if card clicked
        if (Physics.Raycast(ray, out RaycastHit hit,500, cardLayerMask))
        {
            ICard cardClicked = hit.transform.gameObject.GetComponent<ICard>();
            
            if (cardClicked.IsCardInteractable())
            {
                currentClickedCard = cardClicked;
                cardStartPosition = currentClickedCard.GetCardTransform().position;
                Debug.LogError($"Card clicked:{cardClicked.CardID}");
            }
        }
    }

    public void OnTouchMove(Vector3 inputPosition)
    {
        if (currentClickedCard != null)
        {
            Ray ray = camera.ScreenPointToRay(inputPosition);
            
            //Move card
            if (Physics.Raycast(ray, out RaycastHit hit,500, cardMovementLayerMask))
            {
                currentClickedCard.CardMovementManager.SnapToPosition(hit.point);
            }
        }
    }

    public void OnTouchUp()
    {
        if (currentClickedCard != null)
        {
            Ray ray = new Ray(currentClickedCard.GetCardTransform().position, Vector3.down);
            
            //Check if hitting any location placement area
            if (Physics.Raycast(ray, out RaycastHit hit,500, locationLayerMask))
            {
                ILocation location = hit.transform.gameObject.GetComponent<ILocation>();
                
                //move from one location to other location
                if (currentClickedCard.CardStateManager.GetCardCurrentState() == CardState.Location)
                {
                    player.MoveCardToNewLocation(currentClickedCard,currentClickedCard.GetCurrentLocation(),location);
                }
                //move from hand to location
                else
                {
                    player.MoveCardFromHandToLocation(currentClickedCard,location);
                }
            }
            //move card from location to hand
            else if (currentClickedCard.CardStateManager.GetCardCurrentState() == CardState.Location)
            {
                player.MoveCardToHandFromLocation(currentClickedCard,currentClickedCard.GetCurrentLocation());
            }
            //move back to hand
            else 
            {
                player.MoveCardToHand(currentClickedCard,cardStartPosition);
            }
            
            currentClickedCard = null;
        }
    }
}


/*
 TODO:
 - location to location movement
 - location to hand movement
 - lock card at location when player turn ends
 - no input during oppnent's turn
 - hand card auto arrangement
 - AI basic movement
 */