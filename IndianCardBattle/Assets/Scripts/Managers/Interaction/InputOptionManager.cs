using System.Collections.Generic;
using UnityEngine;

public enum InputOptionType
{
    Touch = 0,
    Mouse = 1
}

[System.Serializable]
public struct InputOptionsData
{
    public InputOptionType type;
    public InteractionHandler inputOptionGameObject;
}

/// <summary>
/// Manager class to enable/disable input handlers based on the system
/// selected by user.
/// </summary>
public class InputOptionManager : MonoBehaviour
{
    [SerializeField]
    InputOptionType selectedInputOptionType;

    [SerializeField]
    List<InputOptionsData> inputOptions;
    
    public static InputOptionManager Instance { get; private set; }
    
    #region Monobehaviour
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

#if UNITY_EDITOR
        selectedInputOptionType = InputOptionType.Mouse;
#endif

        EnableInputBasedOnSelectedInputType();
    }
    #endregion

    public InteractionHandler EnableInputBasedOnSelectedInputType()
    {
        InputOptionsData data = inputOptions.Find(x => x.type == selectedInputOptionType);
        data.inputOptionGameObject.gameObject.SetActive(true);
        return data.inputOptionGameObject;
    }
}
