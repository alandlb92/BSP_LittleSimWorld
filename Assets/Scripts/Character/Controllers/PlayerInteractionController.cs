using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractionController
{
    [SerializeField] private CharacterComponent _characterComponent;

    private float _interactionDistance;
    
    private IInteract _iInteract;

    public Vector2 _startPosition;
    public Vector2 _endPosition;

    public IInteract Interactable => _iInteract;

    public PlayerInteractionController(float interactionDistance)
    {
        _interactionDistance = interactionDistance;
    }

    public void Update(Transform transform, Vector2 bodyDirection)
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + bodyDirection * _interactionDistance;

        RaycastHit2D[] hits = Physics2D.RaycastAll(_startPosition, bodyDirection, _interactionDistance);
        RaycastHit2D hit = hits.Where(x => x.collider != null && !x.collider.CompareTag("Player")).FirstOrDefault();

        if (hit.collider != null && hit.collider.GetComponent<DialogInteractionComponent>() != null)
        {
            _iInteract = hit.collider.GetComponent<DialogInteractionComponent>();
        }
        else
            _iInteract = null;
    }
}
