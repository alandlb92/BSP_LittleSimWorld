using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShoesItem", menuName = "Customize Options/Shoes")]
public class ShoesItem : ScriptableObject
{
    public Sprite thumb;
    public Sprite front;
    public Sprite side;
    public Sprite back;
}
