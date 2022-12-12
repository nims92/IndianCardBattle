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
    public GameObject inputOptionGameObject;
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

    #region Monobehaviour
    private void Awake()
    {
#if UNITY_EDITOR
        selectedInputOptionType = InputOptionType.Mouse;
#endif

        EnableInputBasedOnSelectedInputType();
    }
    #endregion

    public void EnableInputBasedOnSelectedInputType()
    {
        InputOptionsData data = inputOptions.Find(x => x.type == selectedInputOptionType);
        data.inputOptionGameObject.SetActive(true);
    }
}
