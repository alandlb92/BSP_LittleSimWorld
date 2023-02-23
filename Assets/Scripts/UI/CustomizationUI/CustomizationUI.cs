using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationUI : MonoBehaviour
{
    [SerializeField] private SkinToneCustomizePanel skinToneCustomizePanel;
    [SerializeField] private EyeColorCustomizePanel eyeColorCustomizePanel;
    [SerializeField] private HairColorCustomizePanel hairColorCustomizePanel;
    [SerializeField] private HairStyleCustomizePanel hairStyleCustomizePanel;
    [SerializeField] private PantsCustomizePanel pantsCustomizePanel;

    public void Configure(ICustomizeCharacter iCustomizeCharacter)
    {
        skinToneCustomizePanel.Initialize(iCustomizeCharacter);
        eyeColorCustomizePanel.Initialize(iCustomizeCharacter);
        hairColorCustomizePanel.Initialize(iCustomizeCharacter);
        hairStyleCustomizePanel.Initialize(iCustomizeCharacter);
        pantsCustomizePanel.Initialize(iCustomizeCharacter);
    }
}
