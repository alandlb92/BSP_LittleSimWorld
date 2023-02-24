using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataExtends
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

    public static StoreUI.Model ToStoreModel(this MerchantData merchantData, ICharacterData ICharacterData)
    {
        StoreUI.Model model = new StoreUI.Model();
        model.itens = new List<StoreUI.ItemOption>();

        foreach (var item in merchantData.ItensToBuy.shirts)
        {
            model.itens.Add(new StoreUI.ItemOption
            {
                thumb = item.shirt.thumb,
                price = item.price,
                type = StoreUI.ItemType.BUY,
                OnTrade = () =>
                {
                    ICharacterData.BuyItem(item);
                }
            });
        }

        foreach (var item in merchantData.ItensToBuy.pants)
        {
            model.itens.Add(new StoreUI.ItemOption
            {
                thumb = item.pant.thumb,
                price = item.price,
                type = StoreUI.ItemType.BUY,
                OnTrade = () =>
                {
                    ICharacterData.BuyItem(item);
                }
            });
        }

        foreach (var item in merchantData.ItensToBuy.shoes)
        {
            model.itens.Add(new StoreUI.ItemOption
            {
                thumb = item.shoes.thumb,
                price = item.price,
                type = StoreUI.ItemType.BUY,
                OnTrade = () =>
                {
                    ICharacterData.BuyItem(item);
                }
            });
        }

        foreach (var item in merchantData.ItensToSell.shirts)
        {
            model.itens.Add(new StoreUI.ItemOption
            {
                thumb = item.shirt.thumb,
                price = item.price,
                type = StoreUI.ItemType.SELL,
                OnTrade = () =>
                {
                    ICharacterData.SellItem(item);
                }
            });
        }

        foreach (var item in merchantData.ItensToSell.pants)
        {
            model.itens.Add(new StoreUI.ItemOption
            {
                thumb = item.pant.thumb,
                price = item.price,
                type = StoreUI.ItemType.SELL,
                OnTrade = () =>
                {
                    ICharacterData.SellItem(item);
                }
            });
        }

        foreach (var item in merchantData.ItensToSell.shoes)
        {
            model.itens.Add(new StoreUI.ItemOption
            {
                thumb = item.shoes.thumb,
                price = item.price,
                type = StoreUI.ItemType.SELL,
                OnTrade = () =>
                {
                    ICharacterData.SellItem(item);
                }
            });
        }

        return model;
    }
}
