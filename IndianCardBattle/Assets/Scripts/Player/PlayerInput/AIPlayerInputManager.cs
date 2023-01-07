using System.Collections;
using UnityEngine;

public class AIPlayerInputManager : MonoBehaviour,IPlayerInputManager
{
    private Player player;
    public bool Interactable { get; set; }
    private LocationManager locationManager;
    private WaitForSeconds delay;
    
    public void SetupPlayerInput(Player player)
    {
        this.player = player;
        locationManager = LocationManager.Instance;
        delay = new WaitForSeconds(1f);
    }

    public void OnPlayerTurnReceived()
    {
        StartCoroutine(RunAILogic());
    }

    private IEnumerator RunAILogic()
    {
        ILocation location = locationManager.GetRandomLocation(player.Profile.GetPlayerID());
        ICard card = player.PlayerCardManager.GetRandomPlayableCardFromHand();
        
        if(card != null)
            player.MoveCardFromHandToLocation(card,location);
        
        yield return delay;
        
        //Force turn end event
        CustomEventManager.Instance.Invoke(UIEvents.END_TURN_BUTTON_PRESSED);
    }

    public void OnPlayerTurnEnded()
    {
        
    }

    public MonoBehaviour GetMonoBehaviourContext()
    {
        return this;
    }
}