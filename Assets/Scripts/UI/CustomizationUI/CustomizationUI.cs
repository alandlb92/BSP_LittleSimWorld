using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationUI : MonoBehaviour
{
    [SerializeField] private SkinToneCustomizePanel skinToneCustomizePanel;
    [SerializeField] private EyeColorCustomizePanel eyeColorCustomizePanel;
    [SerializeField] private HairColorCustomizePanel hairColorCustomizePanel;
    [SerializeField] private HairStyleCustomizePanel hairStyleCustomizePanel;
    [SerializeField] private ShirtsCustomizePanel shirtCustomizePanel;
    [SerializeField] private PantsCustomizePanel pantsCustomizePanel;
    [SerializeField] private ShoesCustomizePanel shoesCustomizePanel;

    [SerializeField] private Button readyButton;

    public void Configure(ICustomizeCharacter iCustomizeCharacter, Action onReady)
    {
        readyButton.onClick.AddListener(() => { onReady.Invoke(); });
        readyButton.onClick.AddListener(() => { Destroy(gameObject); });

        skinToneCustomizePanel.Initialize(iCustomizeCharacter);
        eyeColorCustomizePanel.Initialize(iCustomizeCharacter);
        hairColorCustomizePanel.Initialize(iCustomizeCharacter);
        hairStyleCustomizePanel.Initialize(iCustomizeCharacter);
        shirtCustomizePanel.Initialize(iCustomizeCharacter);
        pantsCustomizePanel.Initialize(iCustomizeCharacter);
        shoesCustomizePanel.Initialize(iCustomizeCharacter);
    }
}
