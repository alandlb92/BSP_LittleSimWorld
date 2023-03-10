using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShirtItem", menuName = "Customize Options/Shirt")]
public class ShirtItem : ScriptableObject
{
    public Sprite thumb;
    public Sprite front;
    public Sprite side;
    public Sprite back;
    public Sprite sleeve;
}
