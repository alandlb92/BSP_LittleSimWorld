using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteractionComponent : MonoBehaviour, IInteract
{
    [SerializeField] private CharacterComponent _self;

    [SerializeField] private string _name;
    [SerializeField] private DialogData _dialog;
    private CharacterComponent _interactingCharacter;

    public void Interact(CharacterComponent characterComponent)
    {
        _interactingCharacter = characterComponent;
    }

    public void GiveMoneyToOther(int amount)
    {
        _interactingCharacter.IInvetory.AddCoins(amount);
    }

    public void AddMoneySelf(int amount)
    {
        _self.IInvetory.AddCoins(amount);
    }
}
