using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : IStore
{
    private StoreUI _ui;
    private ICharacterData _iCharacterData;

    private StoreUI.ItemOption _storeItemSelected;

    public StoreController(StoreUI uiInstance, ICharacterData ICharacterData)
    {
        _ui = uiInstance;
        _ui.OnTrade += OnTrade;
        _iCharacterData = ICharacterData;
        _ui.Hide();
    }

    public void Open(MerchantData merchantData)
    {
        _ui.ShowStore(merchantData.ToStoreModel(_iCharacterData), OnSelect);
    }

    public void OnSelect(StoreUI.ItemOption merchantItemData)
    {
        _storeItemSelected = merchantItemData;
        _ui.UpdateTradeButton(_iCharacterData.CanTrade(_storeItemSelected));
    }

    public void OnTrade()
    {
        _storeItemSelected.OnTrade();
    }
}
