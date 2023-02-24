using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : IInventory
{
    private InventoryUI _ui;
    private ICustomizeCharacter _ICustomize;
    private IGameplayInput _gamePlayInput;


    public InventoryController(InventoryUI uiInstance, ICustomizeCharacter ICustomize, IGameplayInput playerInput)
    {
        _ui = uiInstance;
        _ICustomize = ICustomize;
        _gamePlayInput = playerInput;
        _ui.Hide();
        _ui.OnExit += _gamePlayInput.EnableInput;
    }

    public void Open(CharacterData characterInventoryData)
    {
        _gamePlayInput.DisableInput();
        _ui.ShowInventory(characterInventoryData.ToInventoryModel(_ICustomize));
    }
}
