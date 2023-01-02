using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScreenManager : UIBase
{
    public float timePauseOnLaunchScreen = 2f;

    private void Start()
    {
        Invoke(nameof(GoToGameplayScreen), timePauseOnLaunchScreen);
    }

    private void GoToGameplayScreen()
    {
        UISceneController.Instance.ShowUIScreen(Constants.GAMEPLAY_SCREEN_SCENE_NAME, ScreenManager.UIScreens.InGameScreen);
    }
}
