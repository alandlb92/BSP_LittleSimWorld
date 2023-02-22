using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryController : ICharacterInventory
{
    private CharacterInventoryData _data;
    private IPlayerHUD _HUD;
    
    public CharacterInventoryController(IPlayerHUD hud)
    {
        _HUD = hud;
        _data = new CharacterInventoryData();

        _HUD?.UpdateCoins(_data.coins);
    }

    public void AddCoins(int value)
    {
        _data.coins += value;
        _HUD?.UpdateCoins(_data.coins);
    }
}
