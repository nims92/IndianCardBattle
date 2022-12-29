using UnityEngine;

public interface ILocationViewManager
{
    void InitView(int playerScore, int opponentScore, string locationDescription, string locationName);
    void UpdatePlayerScore(int score);
    void UpdateOpponentScore(int score);
    void UpdateLocationDescriptionText(string descriptionText);
    void UpdateLocationName(string locationName);
    void UpdateLocationBgColor(Color newColor);
}