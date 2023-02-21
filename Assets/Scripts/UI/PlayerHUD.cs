using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour, IPlayerHUD
{
    [SerializeField] private TMP_Text coinsValue;

    public void UpdateCoins(float value)
    {
        coinsValue.text = value.ToString();
    }
}
