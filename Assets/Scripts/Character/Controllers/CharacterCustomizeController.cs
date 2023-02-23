using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomizeController : ICustomizeCharacter
{
    public struct Configuration
    {
        public SpriteRenderer _bodyFront;
        public SpriteRenderer _bodyLeft;
        public SpriteRenderer _bodyBack;
        public SpriteRenderer _hairFront;
        public SpriteRenderer _hairLeft;
        public SpriteRenderer _hairBack;


        public SpriteRenderer _pantRightLegFront;
        public SpriteRenderer _pantRightLegBack;
        public SpriteRenderer _pantRightLegLeft;

        public SpriteRenderer _pantLeftLegFront;
        public SpriteRenderer _pantLeftLegBack;
        public SpriteRenderer _pantLeftLegLeft;

        public SpriteRenderer _pantBodyLegFront;
        public SpriteRenderer _pantBodyLegBack;
        public SpriteRenderer _pantBodyLegLeft;

        public SpriteRenderer _faceFront;
        public SpriteRenderer _faceLeft;
    }

    private Configuration references;

    public CharacterCustomizeController(Configuration configuration)
    {
        references = configuration;
    }

    public void ChangeSkinTone(float h, float s, float v)
    {
        references._bodyFront.material.SetHUEFloatValues(h, s, v);
        references._bodyLeft.material.SetHUEFloatValues(h, s, v);
        references._bodyBack.material.SetHUEFloatValues(h, s, v);
    }
    public void ChangeEyeColor(float h, float s, float v)
    {
        references._faceFront.material.SetHUEFloatValues(h, s, v);
        references._faceLeft.material.SetHUEFloatValues(h, s, v);
    }

    public void ChangeHairColor(float h, float s, float v)
    {
        references._hairFront.material.SetHUEFloatValues(h, s, v);
        references._hairLeft.material.SetHUEFloatValues(h, s, v);
        references._hairBack.material.SetHUEFloatValues(h, s, v);
    }

    public void ChangeHairStyle(HairStyleItem hairStyle)
    {
        references._hairFront.sprite = hairStyle.front;
        references._hairLeft.sprite = hairStyle.left;
        references._hairBack.sprite = hairStyle.back;
    }

    public void ChangePants(PantsItem pants)
    {
        references._pantRightLegFront.sprite = pants.front;
        references._pantLeftLegFront.sprite = pants.front;
        references._pantBodyLegFront.sprite = pants.front;

        references._pantRightLegLeft.sprite = pants.left;
        references._pantLeftLegLeft.sprite = pants.left;
        references._pantBodyLegLeft.sprite = pants.left;

        references._pantRightLegBack.sprite = pants.back;
        references._pantLeftLegBack.sprite = pants.back;
        references._pantBodyLegBack.sprite = pants.back;
    }
}
