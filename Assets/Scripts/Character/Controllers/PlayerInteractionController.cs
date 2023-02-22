using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController
{
    [SerializeField] private CharacterComponent _characterComponent;

    private float _interactionDistance;
    
    private IInteract _iInteract;

    public IInteract Interactable => _iInteract;

    public PlayerInteractionController(float interactionDistance)
    {
        _interactionDistance = interactionDistance;
    }

    public void Update(Transform transform, Vector3 bodyDirection)
    {
        Vector3 _startPosition = transform.position;
        Vector3 _endPosition = _startPosition + bodyDirection * _interactionDistance;

        RaycastHit2D hit = Physics2D.Linecast(_startPosition, _endPosition);

        if(hit.collider != null && hit.collider.GetComponent<DialogInteractionComponent>() != null)
        {
            _iInteract = hit.collider.GetComponent<DialogInteractionComponent>();
        }
    }
}
