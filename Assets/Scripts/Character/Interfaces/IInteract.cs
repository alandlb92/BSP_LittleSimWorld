using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    void Interact(CharacterComponent characterComponent, IDialog iDialog);
}
