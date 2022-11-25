using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;

public class ScreenManager
{
    public enum UIScreens
    {
        NONE,
        LaunchScreen,
        InGameScreen
    };

    private ScreenManager instance = null;

    private Stack<UIScreens> queuedScreens;

    Stack<UIScreens> activeDisplayedScreens;
    private Dictionary<UIScreens, GameObject> screenDict;

    private Transform loadingPanel;

    private Stack<UIScreens> queuedPopupScreens;

    UIScreens lastFullScreen;
    UIScreens lastPopupScreen;

    private UIScreens activeUIScreen;

    public UIScreens ActiveUIScreen { get => activeUIScreen; }

    public ScreenManager()
    {
        queuedScreens = new Stack<UIScreens>();
        queuedPopupScreens = new Stack<UIScreens>();
        activeDisplayedScreens = new Stack<UIScreens>();
        screenDict = new Dictionary<UIScreens, GameObject>();
    }

    public void FindAllScreens()
    {
        GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");

        for (int i = 0; i < canvas.Length; i++)
        {
            UIBase[] screens = canvas[i].GetComponentsInChildren<UIBase>(true);
            for (int j = 0; j < screens.Length; j++)
            {
                AddScreen(screens[j].thisScreen, screens[j].gameObject);
            }
        }
    }

    public void FindAllScreensInGameObject(GameObject parentObj)
    {
        UIBase[] screens = parentObj.GetComponentsInChildren<UIBase>(true);
        for (int j = 0; j < screens.Length; j++)
        {
            AddScreen(screens[j].thisScreen, screens[j].gameObject);
        }
    }

    public void HideAllScreens()
    {
        foreach (KeyValuePair<UIScreens, GameObject> pair in screenDict)
            pair.Value.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ///if(!FTUESystem.Instance.IsFTUEActive)
            BackButtonHandler();
        }
    }

    public void BackButtonHandler()
    {
        if (screenDict.ContainsKey(activeUIScreen))
            screenDict[activeUIScreen].GetComponent<UIBase>().GoBack();
    }

    // called when back is pressed.. on closing the current screen..
    public void GoBack()
    {
        GameObject activeObject = screenDict[activeDisplayedScreens.Peek()];
        if (activeObject == null)
            return;

        UIBase curr = activeObject.GetComponent<UIBase>();
        if (curr.screenType == UIBase.ScreenType.FullScreen)// if the current screen is fullscreen..
        {
            if (curr.canGoBackToPreviousScreen) // if goback is enabled, show the queued screen..
            {
                if (queuedScreens.Count > 0)
                {
                    ShowUIScreen(queuedScreens.Pop(), false, true);
                    if (curr.enablePopupScreenAlsoOnGoingBack)// show the queued popup..
                        ShowUIScreen(queuedPopupScreens.Pop(), false, true);
                }
            }
            //else // remove the active displayed screen and disable it..
            //{
            //	activeDisplayedScreens.Pop ();
            //	screenDict[curr.thisScreen].SetActive (false);		
            //	activeUIScreen = activeDisplayedScreens.Peek();
            //}
        }
        else if (curr.screenType == UIBase.ScreenType.Popup)// if current screen is popupscreen
        {
            if (curr.canGoBackToPreviousScreen)// if goback is enabled, show the screen from the stack..
                ShowUIScreen(queuedPopupScreens.Pop(), false, true);
            else// else disable the current displayed screen..
            {
                activeDisplayedScreens.Pop();
                screenDict[curr.thisScreen].SetActive(false);
                activeUIScreen = activeDisplayedScreens.Peek();
            }
        }
        //#if UNITY_ANDROID
        //CustomEventManager.Instance.Invoke(CustomEventManager.CustomEvents.OnScreenChanged, activeUIScreen);
        //#endif
    }

    T GetComponent<T>(UIScreens screen)
    {
        return screenDict[screen].GetComponent<T>();
    }

    /// <summary>
    /// Using to disable the active screens in the current scene when switching scenes.
    /// </summary>
    // disables all active displayed screens..
    void DisablePrevScreens()
    {
        for (int i = activeDisplayedScreens.Count - 1; i >= 0; i--)
        {
            UIBase prevScreen = GetComponent<UIBase>(activeDisplayedScreens.Pop());
            if (prevScreen != null)
                prevScreen.gameObject.SetActive(false);
        }
        activeDisplayedScreens.Clear();
    }

    /// <summary>
    /// Call this Method to enable a screen and pass parameters to that screen. Override SetParameters Method in the derived class
    /// </summary>
    /// <param name="screen"></param>
    /// <param name="args"></param>
    public void ShowUIScreen(UIScreens screen, params object[] args)
    {
        ShowUIScreen(screen);
        screenDict[screen].GetComponent<UIBase>().SetParameters(args);
    }

    /// <summary>
    /// Call this method to show the screen
    /// </summary>
    /// <param name="screen"></param>
    /// <param name="clearList"></param>
    /// <param name="isClosing"></param>
    public void ShowUIScreen(UIScreens screen, bool clearList = false, bool isClosing = false)
    {
        if (!screenDict.ContainsKey(screen))
        {
            Debug.LogFormat("Screen with name {0} is not found.\n{1}", screen, "Check if Canvas is tagged with 'Canvas'");
            return;
        }

        //Jet.HyperSports.GameData.Instance.PreviousScreenName = screen.ToString();

        if (screen == activeUIScreen) // if the screen is the active ui screen enable the screen and return.(used while coming back to previous scene screen from the next scene. 
        {
            screenDict[screen].SetActive(true);
            //CustomEventManager.Instance.Invoke(CustomEventManager.CustomEvents.OnScreenChanged, screen);
            return;
        }

        if (clearList)
        {
            queuedPopupScreens.Clear();
            queuedScreens.Clear();
            activeUIScreen = UIScreens.NONE;
        }

        UIBase currScreen = screenDict[screen].GetComponent<UIBase>();
        UIBase prevScreen = null;
        if (activeUIScreen != UIScreens.NONE)
            prevScreen = screenDict[activeUIScreen].GetComponent<UIBase>();

        // if current screen type and prev screen type is same then disable the prev screen.. else display the current screen on top of prev screen..
        if (prevScreen != null && currScreen.screenType == prevScreen.screenType)
        {
            activeDisplayedScreens.Pop();
            screenDict[activeUIScreen].SetActive(false);
        }

        if (currScreen.screenType == UIBase.ScreenType.FullScreen)
        {
            DisablePrevScreens();

            if (currScreen.canGoBackToPreviousScreen && !isClosing) // if enabled push it to queue to enable it later..
            {

                queuedScreens.Push(lastFullScreen);
                if (currScreen.enablePopupScreenAlsoOnGoingBack && !isClosing)
                    queuedPopupScreens.Push(lastPopupScreen);   // add previous screen to list..
                else if (!isClosing)// if enablePopupScreenAlsoOnGoingBack is disabled, clear the popups stack ..
                    queuedPopupScreens.Clear();
            }
            else if (!isClosing)// if full screen is shown and goback is disabled clear all stacks ..
            {
                queuedScreens.Clear();
                if (prevScreen != null && !prevScreen.enablePopupScreenAlsoOnGoingBack)
                    queuedPopupScreens.Clear();
            }

            lastFullScreen = screen;
        }
        else if (currScreen.screenType == UIBase.ScreenType.Popup)
        {
            if (currScreen.canGoBackToPreviousScreen && !isClosing) // if enabled push it to queue to enable it later..
                queuedPopupScreens.Push(lastPopupScreen);

            lastPopupScreen = screen;
        }
        if (screen != UIScreens.NONE)
        {
            screenDict[screen].SetActive(true);
        }

        // check if the screen is in queue.. if there then pop the before screens
        CheckInQueue(screen);

        activeUIScreen = screen;
        activeDisplayedScreens.Push(screen);



        //#if UNITY_ANDROID
        //CustomEventManager.Instance.Invoke(CustomEventManager.CustomEvents.OnScreenChanged, screen);
        //#endif
    }

    /// <summary>
    /// if the current screen exists in the queue, Clears the queue till the current screen(remove enums behind the current screen)
    /// </summary>
    void CheckInQueue(UIScreens currentScreen)
    {
        if (queuedScreens.Contains(currentScreen))
        {
            int count = queuedScreens.Count;
            for (int i = 0; i < count; i++)
            {
                queuedScreens.Pop();
                if (queuedScreens.Peek() == lastFullScreen)
                {
                    queuedScreens.Pop(); // remove the current screen from the queue
                    break;
                }
            }
        }
    }
    public void AddScreen(UIScreens scr, GameObject screenObj)
    {
        GameObject screenObject = null;

        if (screenDict.TryGetValue(scr, out screenObject))
            screenDict[scr] = screenObj;
        else
            screenDict.Add(scr, screenObj);
    }

    public GameObject GetScreenObject(UIScreens scr)
    {
        return screenDict[scr];
    }
    //............................................
}
