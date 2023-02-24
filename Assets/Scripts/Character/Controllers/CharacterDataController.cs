using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataController : ICharacterData
{
    private CharacterData _data;
    private IPlayerHUD _HUD;
    private ICustomizeCharacter _iCustomize;

    public CharacterDataController(IPlayerHUD hud, ICustomizeCharacter customizeCharacter)
    {
        _HUD = hud;
        _data = new CharacterData();
        _iCustomize = customizeCharacter;
        _HUD?.UpdateCoins(_data.coins);
    }

    public void AddCoins(int value)
    {
        _data.coins += value;
        _HUD?.UpdateCoins(_data.coins);
    }

    public bool CanTrade(StoreUI.ItemOption storeItemSelected)
    {
        if (storeItemSelected.type == StoreUI.ItemType.BUY)
            return _data.coins >= storeItemSelected.price;
        else
            return _data.shirt.Exists(x => x.thumb == storeItemSelected.thumb) || _data.pants.Exists(x => x.thumb == storeItemSelected.thumb) || _data.shoes.Exists(x => x.thumb == storeItemSelected.thumb);
    }


    public void BuyItem(MerchantPantsItens item)
    {
        AddCoins(-item.price);
        _data.pants.Add(item.pant);
    }

    public void BuyItem(MerchantShirtItens item)
    {
        AddCoins(-item.price);
        _data.shirt.Add(item.shirt);
    }

    public void BuyItem(MerchantShoesItens item)
    {
        AddCoins(-item.price);
        _data.shoes.Add(item.shoes);
    }



    public void SellItem(MerchantPantsItens item)
    {
        AddCoins(item.price);
        _data.pants.Remove(item.pant);

        if (!_data.pants.Contains(item.pant))
            _iCustomize.ChangePants(new PantsItem());
    }

    public void SellItem(MerchantShirtItens item)
    {
        AddCoins(item.price);
        _data.shirt.Remove(item.shirt);

        if (!_data.shirt.Contains(item.shirt))
            _iCustomize.ChangeShirt(new ShirtItem());
    }

    public void SellItem(MerchantShoesItens item)
    {
        AddCoins(item.price);
        _data.shoes.Remove(item.shoes);

        if (!_data.shoes.Contains(item.shoes))
            _iCustomize.ChangeShoes(new ShoesItem());
    }

    public CharacterData GetData()
    {
        return _data;
    }

    public void SetInitializeData(ShirtItem shirtItem, PantsItem pantsItem, ShoesItem shoesItem)
    {
        _data.shirt = new List<ShirtItem> { shirtItem };
        _data.pants = new List<PantsItem> { pantsItem };
        _data.shoes = new List<ShoesItem> { shoesItem };
    }
}
