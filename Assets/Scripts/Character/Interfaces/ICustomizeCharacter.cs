using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomizeCharacter
{
    void ChangeHairColor(float h, float s, float v);
    void ChangeSkinTone(float h, float s, float v);
    void ChangeEyeColor(float h, float s, float v);
    void ChangeHairStyle(HairStyleItem hairStyle);
    void ChangePants(PantsItem pants);
    void ChangeShirt(ShirtItem option);
    void ChangeShoes(ShoesItem option);
    ShirtItem GetCurrentShirt();
    PantsItem GetCurrentPants();
    ShoesItem GetCurrentShoes();


}
