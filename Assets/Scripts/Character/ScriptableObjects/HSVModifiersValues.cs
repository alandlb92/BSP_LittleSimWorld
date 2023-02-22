using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HSVModifier" ,menuName = "Customize Options/HSV Modifier")]
public class HSVModifiersValues : ScriptableObject
{
    public Color toneThunb;
    public float h;
    public float s;
    public float v;
}
