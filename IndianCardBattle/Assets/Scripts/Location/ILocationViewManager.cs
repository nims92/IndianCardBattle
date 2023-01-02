using UnityEngine;

public interface ILocationViewManager
{
    void InitView(int playerScore, int opponentScore, string locationDescription, string locationName);
    void UpdateScore(bool playerScore, int score);
    void UpdateLocationDescriptionText(string descriptionText);
    void UpdateLocationName(string locationName);
    void UpdateLocationBgColor(Color newColor);
    void OnLocationUnlocked();
    void OnPlayerScoresUpdated(int playerScore,int opponentScore);
}