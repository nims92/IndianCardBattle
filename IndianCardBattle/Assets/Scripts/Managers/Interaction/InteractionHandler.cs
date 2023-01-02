using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private Player player;
    private Camera camera;
    private ICard currentClickedCard;
    private Vector3 cardStartPosition;

    [SerializeField] private LayerMask cardLayerMask;
    [SerializeField] private LayerMask locationLayerMask;
    [SerializeField] private LayerMask cardMovementLayerMask;
    
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

    protected virtual void InputUpdate() { }

    protected void OnTouchDown(Vector3 inputPosition)
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
            }
        }
    }

    protected void OnTouchMove(Vector3 inputPosition)
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

    protected void OnTouchUp()
    {
        if (currentClickedCard != null)
        {
            Ray ray = new Ray(currentClickedCard.GetCardTransform().position, Vector3.down);
            
            //Check if hitting any location placement area
            if (Physics.Raycast(ray, out RaycastHit hit,500, locationLayerMask))
            {
                ILocation location = hit.transform.gameObject.GetComponent<ILocation>();
                
                //Check if location has empty space
                if (location.IsLocationFullForPlayer(player.Profile.GetPlayerID()))
                {
                    player.MoveCardToHand(currentClickedCard,cardStartPosition);
                }
                else
                {
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