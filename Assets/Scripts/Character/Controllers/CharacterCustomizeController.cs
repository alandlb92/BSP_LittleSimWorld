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

    public void ChangeStyle(HairStyleItem hairStyle)
    {
        references._hairFront.sprite = hairStyle.front;
        references._hairLeft.sprite = hairStyle.left;
        references._hairBack.sprite = hairStyle.back;
    }
}
