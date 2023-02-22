using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialExtensions
{
    public static void SetHUEFloatValues(this Material material, float h, float s, float v)
    {
        material.SetFloat("_Hue", h);
        material.SetFloat("_Saturation", s);
        material.SetFloat("_Value", v);
    }
}
