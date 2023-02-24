using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public enum ItemType
    {
        BUY,
        SELL
    }

    public struct ItemOption
    {
        public Sprite thumb;
        public ItemType type;
        public int price;
        public Action OnTrade;
    }

    public struct Model
    {
        public List<ItemOption> itens;
    }

    [SerializeField] private GameObject _pivot;
    [SerializeField] private TabGroup _tabGroup;
    [SerializeField] private SelectableButtonGroup _buyGroup;
    [SerializeField] private SelectableButtonGroup _sellGroup;
    [SerializeField] private SelectableButton SelectableButton_reference;

    [SerializeField] private Button _tradeButton;
    [SerializeField] private TMP_Text _tradeButtonText;

    public event Action OnTrade;

    private void Start()
    {
        _tradeButton.onClick.AddListener(Trade);
        _tabGroup.OnBuySelected += () => 
        { 
            _tradeButtonText.text = "BUY"; 
            _buyGroup.SelectByIndex(0);
        };
        _tabGroup.OnSellSelected += () => { 
            _tradeButtonText.text = "SELL";
            _sellGroup.SelectByIndex(0);
        };
    }

    public void ShowStore(Model model, Action<StoreUI.ItemOption> onSelect)
    {
        _pivot.SetActive(true);

        foreach (var item in model.itens)
        {
            SelectableButtonGroup selectableButtonGroup = item.type == ItemType.BUY ? _buyGroup : _sellGroup;
            var btn = Instantiate(SelectableButton_reference, selectableButtonGroup.transform);
            btn.AddListener(() => { 
                onSelect.Invoke(item);
            });
            btn.SetSprite(item.thumb);
            selectableButtonGroup.AddToGroup(btn);
        }

        _tabGroup.BuySelected();
        _buyGroup.SelectByIndex(0);
    }

    public void Hide()
    {
        _pivot?.SetActive(false);
        _buyGroup.Clear();
        _sellGroup.Clear();
    }

    public void UpdateTradeButton(bool canTrade)
    {
        _tradeButton.interactable = canTrade;
    }

    public void Trade()
    {
        OnTrade.Invoke();
    }

}
