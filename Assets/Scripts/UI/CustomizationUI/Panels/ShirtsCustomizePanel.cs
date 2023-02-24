using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShirtsCustomizePanel : MonoBehaviour
{
    [SerializeField] private SelectableButton ChoseButtonTemplate;
    [SerializeField] private SelectableButtonGroup OptionsContainer;

    public void Initialize(ICustomizeCharacter customizeCharacter)
    {
        ShirtItem[] toneOptions = Resources.LoadAll<ShirtItem>("Shirts");        

        foreach (var option in toneOptions)
        {
            var button = Instantiate(ChoseButtonTemplate, OptionsContainer.transform); 
            button.AddListener(() => { 
                Debug.Log("Call button");
                Debug.Log(customizeCharacter == null);
            });
            button.AddListener(() => { customizeCharacter?.ChangeShirt(option); });
            button.SetSprite(option.thumb);
            OptionsContainer.AddToGroup(button);
        }

        OptionsContainer.SelectByIndex(0);
    }


}
