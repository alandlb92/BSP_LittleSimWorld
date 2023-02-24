using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizeController : ICustomizeCharacter
{

    private CustomizableSpritesContainer _customizableSprites;

    public CharacterCustomizeController(CustomizableSpritesContainer customizableSprites)
    {
        _customizableSprites = customizableSprites;
    }

    public void ChangeSkinTone(float h, float s, float v)
    {
        _customizableSprites.bodyFront.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.headFront.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.leftArmFront.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.rightArmFront.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.legsFront.material.SetHUEFloatValues(h, s, v);

        _customizableSprites.bodySide.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.HeadSide.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.leftArmSide.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.rightArmSide.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.leftLegSide.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.rightLegSide.material.SetHUEFloatValues(h, s, v);

        _customizableSprites.bodyBack.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.headBack.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.leftArmBack.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.rightArmBack.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.legsBack.material.SetHUEFloatValues(h, s, v);
    }
    public void ChangeEyeColor(float h, float s, float v)
    {
        _customizableSprites.faceFront.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.faceSide.material.SetHUEFloatValues(h, s, v);
    }

    public void ChangeHairColor(float h, float s, float v)
    {
        _customizableSprites.hairFront.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.hairSide.material.SetHUEFloatValues(h, s, v);
        _customizableSprites.hairBack.material.SetHUEFloatValues(h, s, v);
    }

    public void ChangeHairStyle(HairStyleItem hairStyle)
    {
        _customizableSprites.hairFront.sprite = hairStyle.front;
        _customizableSprites.hairSide.sprite = hairStyle.side;
        _customizableSprites.hairBack.sprite = hairStyle.back;
    }

    public void ChangePants(PantsItem pants)
    {
        _customizableSprites.pantFront.sprite = pants.front;
        _customizableSprites.pantLeftLegSide.sprite = pants.side;
        _customizableSprites.pantRightLegSide.sprite = pants.side;
        _customizableSprites.pantsBack.sprite = pants.back;
    }

    public void ChangeShirt(ShirtItem shirt)
    {
        _customizableSprites.shirtBodyFront.sprite = shirt.front;
        _customizableSprites.shirtBodySide.sprite = shirt.side;
        _customizableSprites.shirtBodyBack.sprite = shirt.back;

        _customizableSprites.shirtLeftSleeveFront.sprite = shirt.sleeve;
        _customizableSprites.shirtRightSleeveFront.sprite = shirt.sleeve;

        _customizableSprites.shirtLeftSleeveSide.sprite = shirt.sleeve;
        _customizableSprites.shirtRightSleeveSide.sprite = shirt.sleeve;

        _customizableSprites.shirtLeftSleeveBack.sprite = shirt.sleeve;
        _customizableSprites.shirtRightSleeveBack.sprite = shirt.sleeve;
    }

    public void ChangeShoes(ShoesItem option)
    {
        _customizableSprites.shoesLeftLegFront.sprite = option.front;
        _customizableSprites.shoesRightLegFront.sprite = option.front;
        _customizableSprites.shoesLeftLegSide.sprite = option.side;
        _customizableSprites.shoesRightLegSide.sprite = option.side;
        _customizableSprites.shoesLeftLegBack.sprite = option.back;
        _customizableSprites.shoesRightLegBack.sprite = option.back;
    }
}
