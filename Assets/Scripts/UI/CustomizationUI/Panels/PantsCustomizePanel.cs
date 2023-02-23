using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantsCustomizePanel : MonoBehaviour
{
    [SerializeField] private SelectableButton ChoseButtonTemplate;
    [SerializeField] private SelectableButtonGroup OptionsContainer;

    public void Initialize(ICustomizeCharacter customizeCharacter)
    {
        PantsItem[] toneOptions = Resources.LoadAll<PantsItem>("Pants");        

        foreach (var option in toneOptions)
        {
            var button = Instantiate(ChoseButtonTemplate, OptionsContainer.transform); 
            button.AddListener(() => { 
                Debug.Log("Call button");
                Debug.Log(customizeCharacter == null);
            });
            button.AddListener(() => { customizeCharacter?.ChangePants(option); });
            button.SetSprite(option.thumb);
            OptionsContainer.AddToGroup(button);
        }

        OptionsContainer.SelectedByIndex(0);
    }


}
