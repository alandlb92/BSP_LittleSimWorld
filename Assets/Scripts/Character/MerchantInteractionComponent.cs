using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInteractionComponent : DialogInteractionComponent
{
    [Header("MERCHANT")]
    [Space]
    [SerializeField] private MerchantData _merchantData;
    [Header("Customize merchant")]
    [SerializeField] private HSVModifiersValues _skinTone;
    [SerializeField] private HSVModifiersValues _hairTone;
    [SerializeField] private HSVModifiersValues _eyesColor;
    [SerializeField] private ShirtItem _shirt;
    [SerializeField] private PantsItem _pants;
    [SerializeField] private ShoesItem _shoes;
    [SerializeField] private HairStyleItem _hair;

    private void Start()
    {
        _self.ICustomize.ChangeShirt(_shirt);
        _self.ICustomize.ChangePants(_pants);   
        _self.ICustomize.ChangeShoes(_shoes);
        _self.ICustomize.ChangeHairStyle(_hair);
        _self.ICustomize.ChangeSkinTone(_skinTone.h, _skinTone.s, _skinTone.v);
        _self.ICustomize.ChangeEyeColor(_eyesColor.h, _eyesColor.s, _eyesColor.v);
        _self.ICustomize.ChangeHairColor(_hairTone.h, _hairTone.s, _hairTone.v);
    }

    protected override void EventMaster(DialogEvent dialogEvent)
    {
        base.EventMaster(dialogEvent);

        if (dialogEvent.type == DialogEventType.OPEN_STORE)
            OpenStore();
    }

    public void OpenStore()
    {
        _playerInteraction.GetIStore().Open(_merchantData);
    }
}
