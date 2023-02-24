using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color deselectedColor;

    [SerializeField] private Image buyBtn;
    [SerializeField] private Image sellBtn;

    [SerializeField] private GameObject buyContainer;
    [SerializeField] private GameObject sellContainer;

    public event Action OnBuySelected;
    public event Action OnSellSelected;

    public void BuySelected()
    {
        buyContainer.gameObject.SetActive(true);
        sellContainer.gameObject.SetActive(false);
        buyBtn.color = selectedColor;
        sellBtn.color = deselectedColor;
        OnBuySelected?.Invoke();

    }

    public void SellSelected()
    {
        buyContainer.gameObject.SetActive(false);
        sellContainer.gameObject.SetActive(true);
        buyBtn.color = deselectedColor;
        sellBtn.color = selectedColor;
        OnSellSelected?.Invoke();
    }

}
