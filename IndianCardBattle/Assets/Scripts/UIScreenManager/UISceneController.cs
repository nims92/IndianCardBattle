using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneController : MonoBehaviour
{
    Dictionary<string, ScreenManager> screensInScenes;

    private static UISceneController instance;

    private string currentSceneName;
    private ScreenManager currentScreenManager;
    [SerializeField]
    private ScreenManager.UIScreens screenToShow = ScreenManager.UIScreens.NONE;

    public static UISceneController Instance
    {
        get { return instance; }
    }

    public ScreenManager CurrentScreenManager { get => currentScreenManager; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        screensInScenes = new Dictionary<string, ScreenManager>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasLoaded;
    }

    private void OnSceneWasLoaded(Scene arg0, LoadSceneMode arg1)
    {
        ScreenManager screenManager = null;
        currentSceneName = arg0.name;
        if (screensInScenes.ContainsKey(currentSceneName))
        {
            screenManager = screensInScenes[currentSceneName];
        }
        else
        {
            screenManager = new ScreenManager();
            screensInScenes.Add(currentSceneName, screenManager);
        }

        screenManager.FindAllScreens();

        currentScreenManager = screenManager;
        if (screenToShow != ScreenManager.UIScreens.NONE)
        {
            currentScreenManager.HideAllScreens(); // added to hide dont destroy on load screens on scene transitions..
            ShowUIScreen(screenToShow);
            screenToShow = ScreenManager.UIScreens.NONE;
        }
    }

    public void ShowUIScreenWithParam(ScreenManager.UIScreens uiScreen, params object[] args)
    {
        currentScreenManager.ShowUIScreen(uiScreen, args);
    }
    public void ShowUIScreen(ScreenManager.UIScreens uiScreen)
    {
        //AnalyticsEventsManager.SetLandedOnScreenEvent(currentScreenManager.ActiveUIScreen.ToString(), uiScreen.ToString());
        currentScreenManager.ShowUIScreen(uiScreen);
    }

    public void ShowUIScreenWithParam(in string sceneName, ScreenManager.UIScreens uiScreen, params object[] args)
    {
        if (string.Equals(currentSceneName, sceneName))
            currentScreenManager.ShowUIScreen(uiScreen, args);
        else
        {
            screenToShow = uiScreen;
            ChangeSceneTo(sceneName);
        }
    }
    public void ShowUIScreen(in string sceneName, ScreenManager.UIScreens uiScreen)
    {
        if (string.Equals(currentSceneName, sceneName))
            currentScreenManager.ShowUIScreen(uiScreen);
        else
        {
            screenToShow = uiScreen;
            ChangeSceneTo(sceneName);
        }
    }

    public void OnBackButtonPressed()
    {
        currentScreenManager.BackButtonHandler();
    }

    public void GoToPreviousScreen()
    {
        currentScreenManager.GoBack();
    }
    // Update is called once per frame
    void Update()
    {
        if (currentScreenManager != null)
            currentScreenManager.Update();
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
