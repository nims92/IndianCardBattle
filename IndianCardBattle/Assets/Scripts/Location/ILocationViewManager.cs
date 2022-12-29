using UnityEngine;

public interface ILocationViewManager
{
    void UpdatePlayerScore(int score);
    void UpdateOpponentScore(int score);
    void UpdateLocationDescriptionText(string descriptionText);
    void UpdateLocationName(string locationName);
    void UpdateLocationBgColor(Color newColor);
}