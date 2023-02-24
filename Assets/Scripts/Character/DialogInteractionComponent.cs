using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteractionComponent : MonoBehaviour, IInteract
{
    [SerializeField] private CharacterComponent _self;

    [SerializeField] private string _name;
    [SerializeField] private DialogData _dialog;
    private CharacterComponent _interactingCharacter;

    private void Awake()
    {
        _dialog.EventMaster = EventMaster;
    }

    private void EventMaster(DialogEvent dialogEvent)
    {
        switch(dialogEvent.type)
        {
            case DialogEventType.ADD_MONEY_SELF:
                AddMoneySelf(dialogEvent.intParam);
                break;
            case DialogEventType.GIVE_MONEY_TO_OTHER:
                GiveMoneyToOther(dialogEvent.intParam);
                break;
            case DialogEventType.NONE:
            default:
                break;
        }
    }

    public void Interact(CharacterComponent characterComponent, IDialog iDialog)
    {
        _interactingCharacter = characterComponent;
        iDialog.ShowDialog(_dialog);
    }

    private void GiveMoneyToOther(int amount)
    {
        Debug.Log("GIVE MONE => " + amount);
        _interactingCharacter.IInvetory.AddCoins(amount);
    }

    private void AddMoneySelf(int amount)
    {
        _self.IInvetory.AddCoins(amount);
    }
}
