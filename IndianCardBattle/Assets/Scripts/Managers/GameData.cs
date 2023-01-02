using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private GameConfiguration gameConfiguration;
    
    [Space(10)]
    [SerializeField] private LocationDatabase locationDatabase;
    [SerializeField] private CardDatabase cardDatabase;
    
    [Space(10)]
    [SerializeField] private CheatData cheatData;

    public static GameData Instance { get; private set; }

    public LocationDatabase LocationDatabase
    {
        get => locationDatabase;
    }

    public CheatData CheatData
    {
        get => cheatData;
    }

    public CardDatabase CardDatabase
    {
        get => cardDatabase;
    }

    public GameConfiguration GameConfiguration
    {
        get => gameConfiguration;
    }

    public GameplayData GameplayData
    {
        get => gameplayData;
        set => gameplayData = value;
    }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
}
