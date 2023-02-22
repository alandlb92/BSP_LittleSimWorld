using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryData
{
    public int coins;
    public List<OutfitData> outFits; 
}

public class OutfitData
{
    public string name;
    public Sprite thumb;
}