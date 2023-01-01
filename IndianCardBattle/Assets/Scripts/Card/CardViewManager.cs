using TMPro;
using UnityEngine;

public class CardViewManager : MonoBehaviour,ICardViewManager
{
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private CanvasGroup canvasGroup;

    public void InitCardViewManager(string cardName, int cost, int power)
    {
        UpdateCardName(cardName);
        UpdateCardCost(cost);
        UpdateCardPower(power);
    }
    
    public void UpdateCardName(string cardName)
    {
        cardNameText.text = cardName;
    }

    public void UpdateCardCost(int cost)
    {
        costText.text = string.Empty + cost;
    }

    public void UpdateCardPower(int power)
    {
        powerText.text = string.Empty + power;
    }

    public void SetCardActive(bool value)
    {
        canvasGroup.alpha = value ? 1 : 0.4f;
    }
}
