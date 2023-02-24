using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("UI Prefabs")]
    [SerializeField] private StartUI StartUI_Referece;
    [SerializeField] private CustomizationUI CustomizationUI_Referece;
    [SerializeField] private DialogUI DialogUI_Reference;
    [SerializeField] private InventoryUI InventoryUI_Reference;

    [Header("References")]
    [SerializeField] private Canvas _mainCanvas;

    private DialogController _dialogController;
    private InventoryController _inventoryController;

    public IDialog IDialog => _dialogController;
    public IInventory IInventory => _inventoryController;

    public void ConfigurePlayerUIS(IGameplayInput _input, ICustomizeCharacter _iCustomize)
    {        
        _dialogController = new DialogController(Instantiate(DialogUI_Reference, _mainCanvas.transform), _input);
        _inventoryController = new InventoryController(Instantiate(InventoryUI_Reference, _mainCanvas.transform), _iCustomize, _input);
    }

    private void Update()
    {
        _dialogController?.Update();
    }

    public void ShowStartUI(IStartOptions IStartOptions)
    {
        Instantiate(StartUI_Referece, _mainCanvas.transform).Configure(IStartOptions);
    }

    public void ShowCustomizeUI(ICustomizeCharacter ICustomize, Action onReady)
    {
        Instantiate(CustomizationUI_Referece, _mainCanvas.transform).Configure(ICustomize, onReady);
    }

    public Transform GetCanvasTransform()
    {
        return _mainCanvas.transform;   
    }
}
