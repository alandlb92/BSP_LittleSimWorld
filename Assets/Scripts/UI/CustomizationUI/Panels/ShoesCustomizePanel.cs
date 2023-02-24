using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoesCustomizePanel : MonoBehaviour
{
    [SerializeField] private SelectableButton ChoseButtonTemplate;
    [SerializeField] private SelectableButtonGroup OptionsContainer;

    public void Initialize(ICustomizeCharacter customizeCharacter)
    {
        ShoesItem[] shoesOptions = Resources.LoadAll<ShoesItem>("Shoes");        

        foreach (var option in shoesOptions)
        {
            var button = Instantiate(ChoseButtonTemplate, OptionsContainer.transform); 
            button.AddListener(() => { 
                Debug.Log("Call button");
                Debug.Log(customizeCharacter == null);
            });
            button.AddListener(() => { customizeCharacter?.ChangeShoes(option); });
            button.SetSprite(option.thumb);
            OptionsContainer.AddToGroup(button);
        }

        OptionsContainer.SelectedByIndex(0);
    }


}
