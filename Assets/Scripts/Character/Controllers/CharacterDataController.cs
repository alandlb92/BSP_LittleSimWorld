using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataController : ICharacterData
{
    private CharacterData _data;
    private IPlayerHUD _HUD;
    
    public CharacterDataController(IPlayerHUD hud)
    {
        _HUD = hud;
        _data = new CharacterData();

        _HUD?.UpdateCoins(_data.coins);
    }

    public void AddCoins(int value)
    {
        _data.coins += value;
        _HUD?.UpdateCoins(_data.coins);
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
