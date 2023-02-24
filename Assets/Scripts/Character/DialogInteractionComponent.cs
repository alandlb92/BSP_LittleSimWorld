using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteractionComponent : MonoBehaviour, IInteract
{
    [SerializeField] protected CharacterComponent _self;
    protected IPlayerInteraction _playerInteraction;

    [SerializeField] private string _name;
    [SerializeField] private DialogData _dialog;

    private void Awake()
    {
        _dialog.EventMaster = EventMaster;
    }

    protected virtual void EventMaster(DialogEvent dialogEvent)
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

    public void Interact(CharacterComponent characterComponent, IPlayerInteraction playerInteraction)
    {
        _playerInteraction = playerInteraction;
        playerInteraction.GetIDialog().ShowDialog(_dialog);
    }

    private void GiveMoneyToOther(int amount)
    {
        Debug.Log("GIVE MONE => " + amount);
        _playerInteraction.GetIData().AddCoins(amount);
    }

    private void AddMoneySelf(int amount)
    {
        _self.IData.AddCoins(amount);
    }
}
