using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// User interface screen. 
/// attach this to all ui screens and select the appropriate screen id
/// </summary>
public class UIBase : MonoBehaviour
{
    public enum ScreenType
    {
        FullScreen,
        Popup,
    }

    public ScreenType screenType;
    public ScreenManager.UIScreens thisScreen;
    public bool canGoBackToPreviousScreen;

    public bool enablePopupScreenAlsoOnGoingBack; // enable this if u want to show popupscreens also on closing full screen..

    public virtual void GoBack()
    {
        UISceneController.Instance.GoToPreviousScreen();
    }

    protected void Awake()
    {
        Button[] buttons = transform.GetComponentsInChildren<Button>(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            Button clickedButton = buttons[i];
            clickedButton.onClick.AddListener(() => { OnClick(clickedButton.name); });
        }

        Toggle[] grp = transform.GetComponentsInChildren<Toggle>(true);
        foreach (Toggle t in grp)
        {
            Toggle currentToggle = t;
            currentToggle.onValueChanged.AddListener((bool value) => OnToggle(value, currentToggle.name));
        }
    }

    public virtual void SetParameters(params object[] args)
    {

    }
    /// <summary>
    /// onClick listener for all buttons under the screen
    /// </summary>
    /// <param name="name"></param>
	public virtual void OnClick(string name)
    {
        // Play button click sound


        if (name.Equals("Close") || name.Equals("Back"))
        {
            //AudioHandler.Instance.PlayUIClickSound();
            GoBack();
        }

    }

    /// <summary>
    /// onValueChanged listener for all toggles under the screen
    /// </summary>
    /// <param name="value"></param>
    /// <param name="toggleName"></param>
	public virtual void OnToggle(bool value, string toggleName)
    {
        // Play toggle sound
    }
}
