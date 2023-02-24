using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterInventoryDataExtends
{
    public static InventoryUI.Model ToInventoryModel(this CharacterData data, ICustomizeCharacter ICustomize)
    {
        InventoryUI.Model model = new InventoryUI.Model();

        model.itens = new List<InventoryUI.ItemOption>();

        foreach (var item in data.pants)
        {
            model.itens.Add(new InventoryUI.ItemOption { thumb = item.thumb, OnClick = () => { ICustomize.ChangePants(item); } });
        }

        foreach (var item in data.shoes)
        {
            model.itens.Add(new InventoryUI.ItemOption { thumb = item.thumb, OnClick = () => { ICustomize.ChangeShoes(item); } });
        }

        foreach (var item in data.shirt)
        {
            model.itens.Add(new InventoryUI.ItemOption { thumb = item.thumb, OnClick = () => { ICustomize.ChangeShirt(item); } });
        }

        return model;
    }
}
