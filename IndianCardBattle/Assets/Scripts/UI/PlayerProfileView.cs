using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProfileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;

    public void Init(string name)
    {
        playerName.text = name;
    }
}
