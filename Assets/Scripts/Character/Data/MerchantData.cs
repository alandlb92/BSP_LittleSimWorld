using System;
using System.Collections.Generic;

[Serializable]
public class MerchantData
{
    public MerchantItens ItensToBuy;
    public MerchantItens ItensToSell;
}

[Serializable]
public class MerchantItens
{
    public List<MerchantShirtItens> shirts;
    public List<MerchantPantsItens> pants;
    public List<MerchantShoesItens> shoes;
}

[Serializable]
public struct MerchantShirtItens
{
    public ShirtItem shirt;
    public int price;
}

[Serializable]
public struct MerchantPantsItens
{
    public PantsItem pant;
    public int price;
}

[Serializable]
public struct MerchantShoesItens
{
    public ShoesItem shoes;
    public int price;
}
