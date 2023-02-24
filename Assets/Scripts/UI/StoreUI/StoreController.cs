using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : IStore
{
    private StoreUI _ui;
    private ICharacterData _iCharacterData;
    private IGameplayInput _gameplayInput;

    private StoreUI.ItemOption _storeItemSelected;

    public StoreController(StoreUI uiInstance, ICharacterData ICharacterData, IGameplayInput gameplayInput)
    {
        _ui = uiInstance;
        _gameplayInput = gameplayInput;
        _ui.OnTrade += OnTrade;
        _iCharacterData = ICharacterData;
        _ui.Hide();
        _ui.OnClose += _gameplayInput.EnableInput;
    }

    public void Open(MerchantData merchantData)
    {
        _ui.ShowStore(merchantData.ToStoreModel(_iCharacterData), OnSelect);
        _ui.StartCoroutine(DisableInput());
    }

    IEnumerator DisableInput()
    {
        yield return new WaitForEndOfFrame();
        _gameplayInput.DisableInput();
    }

    public void OnSelect(StoreUI.ItemOption merchantItemData)
    {
        _storeItemSelected = merchantItemData;
        _ui.UpdateTradeButton(_iCharacterData.CanTrade(_storeItemSelected));
    }

    public void OnTrade()
    {
        _storeItemSelected.OnTrade();
        _ui.UpdateTradeButton(_iCharacterData.CanTrade(_storeItemSelected));
    }
}
