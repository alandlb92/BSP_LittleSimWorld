using System;
using UnityEngine;

[Serializable]
public class CustomizableSpritesContainer
{
    [Header("Customizable Elements")]
    [Header("Body")]
    public SpriteRenderer headFront;
    public SpriteRenderer bodyFront;
    public SpriteRenderer leftArmFront;
    public SpriteRenderer rightArmFront;
    public SpriteRenderer legsFront;
    [Space]
    public SpriteRenderer HeadSide;
    public SpriteRenderer bodySide;
    public SpriteRenderer leftArmSide;
    public SpriteRenderer rightArmSide;
    public SpriteRenderer leftLegSide;
    public SpriteRenderer rightLegSide;
    [Space]
    public SpriteRenderer headBack;
    public SpriteRenderer bodyBack;
    public SpriteRenderer leftArmBack;
    public SpriteRenderer rightArmBack;
    public SpriteRenderer legsBack;

    [Header("Hair")]
    public SpriteRenderer hairFront;
    public SpriteRenderer hairSide;
    public SpriteRenderer hairBack;

    [Header("Eyes")]
    public SpriteRenderer faceFront;
    public SpriteRenderer faceSide;

    [Header("Shirt")]
    public SpriteRenderer shirtBodyFront;
    public SpriteRenderer shirtLeftSleeveFront;
    public SpriteRenderer shirtRightSleeveFront;
    [Space]
    public SpriteRenderer shirtBodySide;
    public SpriteRenderer shirtLeftSleeveSide;
    public SpriteRenderer shirtRightSleeveSide;
    [Space]
    public SpriteRenderer shirtBodyBack;
    public SpriteRenderer shirtLeftSleeveBack;
    public SpriteRenderer shirtRightSleeveBack;

    [Header("Pants")]
    public SpriteRenderer pantFront;
    public SpriteRenderer pantLeftLegSide;
    public SpriteRenderer pantRightLegSide;
    public SpriteRenderer pantsBack;

    [Header("Shoes")]
    public SpriteRenderer shoesLeftLegFront;
    public SpriteRenderer shoesRightLegFront;
    [Space]
    public SpriteRenderer shoesLeftLegSide;
    public SpriteRenderer shoesRightLegSide;
    [Space]
    public SpriteRenderer shoesLeftLegBack;
    public SpriteRenderer shoesRightLegBack;
}
