using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInteraction
{
    IDialog GetIDialog();
    IStore GetIStore();
    ICharacterData GetIData();
}
