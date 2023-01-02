using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationViewManager : MonoBehaviour, ILocationViewManager
{
    #region Scene references
    [SerializeField] private Image playerScoreImage;
    [SerializeField] private Image opponentScoreImage;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI opponentScoreText;
    [SerializeField] private TextMeshProUGUI locationDescriptionText;
    [SerializeField] private TextMeshProUGUI locationNameText;
    [SerializeField] private Image locationBGImage;
    [SerializeField] private GameObject lockIcon;
    #endregion

    public void InitView(int playerScore,int opponentScore,string locationDescription,string locationName)
    {
        UpdatePlayerScore(playerScore);
        UpdateOpponentScore(opponentScore);
        UpdateLocationName(locationName);
        UpdateLocationDescriptionText(locationDescription);
    }

    public void UpdateScore(bool playerScore, int score)
    {
        if (playerScore)
            UpdatePlayerScore(score);
        else 
            UpdateOpponentScore(score);
    }
    
    public void UpdatePlayerScore(int score)
    {
        playerScoreText.text = string.Empty + score;
    }

    public void UpdateOpponentScore(int score)
    {
        opponentScoreText.text = string.Empty + score;
    }

    public void UpdateLocationDescriptionText(string descriptionText)
    {
        locationDescriptionText.text = string.Empty + descriptionText;
    }

    public void UpdateLocationName(string locationName)
    {
        locationNameText.text = string.Empty + locationName;
    }

    public void UpdateLocationBgColor(Color newColor)
    {
        locationBGImage.color = newColor;
    }

    public void OnLocationUnlocked()
    {
        lockIcon.SetActive(false);
    }

    public void OnPlayerScoresUpdated(int playerScore, int opponentScore)
    {
        if (playerScore > opponentScore)
        {
            EnableHighScoreHighlight(0, true);
            EnableHighScoreHighlight(1, false);
        }
        else if (playerScore < opponentScore)
        {
            EnableHighScoreHighlight(1, true);
            EnableHighScoreHighlight(0, false);
        }
        else
        {
            EnableHighScoreHighlight(0, false);
            EnableHighScoreHighlight(1, false);
        }
    }

    private void EnableHighScoreHighlight(int playerIndex, bool value)
    {
        Color newColor = value ? Color.green : Color.white;
        
        if (playerIndex == 0)
            playerScoreImage.color = newColor;
        else
            opponentScoreImage.color = newColor;
    }
}