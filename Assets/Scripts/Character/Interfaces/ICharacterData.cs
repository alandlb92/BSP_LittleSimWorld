using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterData
{
    void AddCoins(int value);
    void BuyItem(MerchantPantsItens item);
    void BuyItem(MerchantShirtItens item);
    void BuyItem(MerchantShoesItens item);
    void SellItem(MerchantPantsItens item);
    void SellItem(MerchantShirtItens item);
    void SellItem(MerchantShoesItens item);
    bool CanTrade(StoreUI.ItemOption storeItemSelected);
}
