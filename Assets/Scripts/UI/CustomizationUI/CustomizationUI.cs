using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationUI : MonoBehaviour
{
    [SerializeField] public SkinToneCustomizePanel skinToneCustomizePanel;
    [SerializeField] public EyeColorCustomizePanel eyeColorCustomizePanel;
    [SerializeField] public HairColorCustomizePanel hairColorCustomizePanel;
    [SerializeField] public HairStyleCustomizePanel hairStyleCustomizePanel;

    public void Configure(ICustomizeCharacter iCustomizeCharacter)
    {
        skinToneCustomizePanel.Initialize(iCustomizeCharacter);
        eyeColorCustomizePanel.Initialize(iCustomizeCharacter);
        hairColorCustomizePanel.Initialize(iCustomizeCharacter);
        hairStyleCustomizePanel.Initialize(iCustomizeCharacter);
    }
}
