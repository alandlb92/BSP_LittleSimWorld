using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinTone" ,menuName = "Customize Options/Skin Tone")]
public class SkinToneOption : ScriptableObject
{
    public Color toneThunb;
    public float h;
    public float s;
    public float v;
}
