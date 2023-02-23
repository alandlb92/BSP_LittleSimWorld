using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairColorCustomizePanel : MonoBehaviour
{
    [SerializeField] private SelectableButton ChoseButtonTemplate;
    [SerializeField] private SelectableButtonGroup OptionsContainer;

    public void Initialize(ICustomizeCharacter customizeCharacter)
    {
        HSVModifiersValues[] toneOptions = Resources.LoadAll<HSVModifiersValues>("HairColors");        

        foreach (var option in toneOptions)
        {
            var button = Instantiate(ChoseButtonTemplate, OptionsContainer.transform); 
            button.AddListener(() => { 
                Debug.Log("Call button");
                Debug.Log(customizeCharacter == null);
            });
            button.AddListener(() => { customizeCharacter?.ChangeHairColor(option.h, option.s, option.v); });
            button.SetColor(option.toneThunb);
            OptionsContainer.AddToGroup(button);
        }

        OptionsContainer.SelectedByIndex(0);
    }


}
