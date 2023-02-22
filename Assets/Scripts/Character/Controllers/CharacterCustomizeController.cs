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
    }

    private Configuration references;

    public CharacterCustomizeController(Configuration configuration)
    {
        references = configuration;
    }

    public void ChangeSkinTone(float h, float s, float v)
    {
        Debug.Log("Changing color");
        references._bodyFront.material.SetHUEFloatValues(h, s, v);
        references._bodyLeft.material.SetHUEFloatValues(h, s, v);
        references._bodyBack.material.SetHUEFloatValues(h, s, v);
    }
}
