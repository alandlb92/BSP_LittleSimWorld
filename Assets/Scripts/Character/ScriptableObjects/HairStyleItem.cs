using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HairStyleItem", menuName = "Customize Options/Hair Style")]
public class HairStyleItem : ScriptableObject
{
    public Sprite thumb;
    public Sprite front;
    public Sprite left;
    public Sprite back;
}
