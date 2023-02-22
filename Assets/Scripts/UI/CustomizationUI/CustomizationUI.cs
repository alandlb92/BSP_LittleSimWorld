using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationUI : MonoBehaviour
{
    [SerializeField] public SkinToneCustomizeUI skinToneCustomize;

    public void Configure(ICustomizeCharacter iCustomizeCharacter)
    {
        skinToneCustomize.Initialize(iCustomizeCharacter);
    }
}
