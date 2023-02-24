using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public struct ItemOption
    {
        public Sprite thumb;
        public Action OnClick;
    }

    public struct Model
    {
        public List<ItemOption> itens;
    }

    [SerializeField] private SelectableButton SelectableButton_reference;
    [SerializeField] private SelectableButtonGroup _selectableButtonGroup;
    [SerializeField] private GameObject _pivot;
    [SerializeField] private Button _closeButton;

    public event Action OnExit;

    private void Start()
    {
        _closeButton.onClick.AddListener(Hide);
    }

    public void ShowInventory(Model inventoryUIModel)
    {
        _pivot.SetActive(true);
        BuildInventory(inventoryUIModel);
    }

    public void Hide()
    {
        _pivot.SetActive(false);
        _selectableButtonGroup.Clear();
        OnExit?.Invoke();
    }

    private void BuildInventory(Model inventoryUIModel)
    {
        foreach (var item in inventoryUIModel.itens)
        {
            var btn = Instantiate(SelectableButton_reference, _selectableButtonGroup.transform);
            btn.AddListener(() => { item.OnClick(); });
            btn.SetSprite(item.thumb);
            _selectableButtonGroup.AddToGroup(btn);
        }
    }
}
