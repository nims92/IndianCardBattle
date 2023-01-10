using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTimerUI : MonoBehaviour
{
    [SerializeField] private Slider timer;
    private float currentTime;
    private float totalTime;
    private Action timerEndCallback;
    
    public void StartTimer(int timeValue,Action callback)
    {
        totalTime = timeValue;
        currentTime = totalTime;
        timerEndCallback = callback;
        InvokeRepeating(nameof(UpdateTimer),0,Time.deltaTime);
    }

    private void UpdateTimer()
    {
        currentTime-= Time.deltaTime;
        if (currentTime < 0)
        {
            OnTimerEnd();
            return;
        }

        UpdateTimerValue(currentTime / totalTime);
    }

    private void UpdateTimerValue(float value)
    {
        timer.value = value;
    }

    private void OnTimerEnd()
    {
        CancelInvoke(nameof(UpdateTimer));
        UpdateTimerValue(0f);
        timerEndCallback?.Invoke();
    }

    public void ResetTimer()
    {
        CancelInvoke(nameof(UpdateTimer));
        UpdateTimerValue(1);
    }
}
