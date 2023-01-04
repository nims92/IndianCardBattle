using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private GameConfiguration gameConfiguration;
    [SerializeField] private AnimationData animationData;
    
    [Space(10)]
    [SerializeField] private LocationDatabase locationDatabase;
    [SerializeField] private CardDatabase cardDatabase;
    
    [Space(10)]
    [SerializeField] private CheatData cheatData;

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
    }
    
    public AnimationData AnimationData
    {
        get => animationData;
    }
    
    #region Singleton
    public static GameData Instance { get; private set; }
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
    #endregion
    
}
