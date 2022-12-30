using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreenManager : UIBase
{
    [Header("Scene Reference")] 
    [SerializeField] private Button turnButton;
    [SerializeField] private TextMeshProUGUI turnButtonText;
    [SerializeField] private PlayerProfileView selfPlayerProfileView;
    [SerializeField] private PlayerProfileView opponentPlayerProfileView;
    [SerializeField] private TextMeshProUGUI costCounterText;
}
