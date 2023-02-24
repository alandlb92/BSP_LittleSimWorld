using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractionController : IPlayerInteraction
{
    private float _interactionDistance;

    private IInteract _CurrentiInteract;
 
    private IDialog _iDialog;
    private IStore _iStore;
    private ICharacterData _iCharacterData;

    public Vector2 _startPosition;
    public Vector2 _endPosition;

    public PlayerInteractionController(float interactionDistance, IDialog iDialog, IStore iStore, ICharacterData icharacterData)
    {
        _interactionDistance = interactionDistance;
        _iDialog = iDialog;
        _iStore = iStore;
        _iCharacterData = icharacterData;
    }

    public void Update(Transform transform, Vector2 bodyDirection)
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + bodyDirection * _interactionDistance;

        RaycastHit2D[] hits = Physics2D.RaycastAll(_startPosition, bodyDirection, _interactionDistance);
        RaycastHit2D hit = hits.Where(x => x.collider != null && !x.collider.CompareTag("Player")).FirstOrDefault();

        if (hit.collider != null && hit.collider.GetComponent<DialogInteractionComponent>() != null)
        {
            _CurrentiInteract = hit.collider.GetComponent<DialogInteractionComponent>();
        }
        else
            _CurrentiInteract = null;
    }

    public void TryToInteract(CharacterComponent characterComponent)
    {
        _CurrentiInteract?.Interact(characterComponent, this);
    }

    public IDialog GetIDialog()
    {
        return _iDialog;
    }

    public IStore GetIStore()
    {
        return _iStore;
    }

    public ICharacterData GetIData()
    {
        return _iCharacterData;
    }
}
