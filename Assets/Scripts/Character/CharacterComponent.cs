using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [Header("UI references to instantiate")]
    [SerializeField] private PlayerHUD PlayerHud_Reference;

    [Space]
    [Header("Physics")]
    [SerializeField] private float velocityMultiply;
    [SerializeField] private Rigidbody2D rBody;

    [Space]
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bodyFront;
    [SerializeField] private GameObject bodySide;
    [SerializeField] private GameObject bodyBack;

    [Space]
    [SerializeField] private CustomizableSpritesContainer _customizableSprites;

    [Space]
    [Header("INPUT")]
    [Space]
    [SerializeField] private InputBase _input;

    [Space]
    [Header("PLAYER")]
    [Space]
    [Header("Interaction")]
    [SerializeField] private float interactionDistance;
    [Space]
    [Header("Camera")]
    [SerializeField] private Camera PlayerCamera;



    private CharacterCustomizeController _customizeController;
    private CharacterAnimationController _animationController;
    private CharacterMovementController _movementController;
    private CharacterInventoryController _inventoryController;
    private PlayerInteractionController _interactionController;
    private PlayerHUD _Hud;
    private PlayerCameraController _cameraController;

    public ICharacterInventory IInvetory => _inventoryController;
    public ICustomizeCharacter ICustomize => _customizeController;
    public IPlayerCamera ICamera => _cameraController;
    public IGameplayInput IInput => _input as PlayerInput;

    private void Awake()
    {

        _movementController = new CharacterMovementController(rBody, velocityMultiply);
        _animationController = new CharacterAnimationController(
            new CharacterAnimationController.Configuration
            {
                _animator = animator,
                _bodyBack = bodyBack,
                _bodyFront = bodyFront,
                _bodySide = bodySide,
                _rigidbody = rBody
            });

        if (PlayerHud_Reference)
            _Hud = Instantiate(PlayerHud_Reference);

        _customizeController = new CharacterCustomizeController(_customizableSprites);

        _inventoryController = new CharacterInventoryController(_Hud);
        _input?.SetUp(_movementController);
    }

    public void InitializePlayer(Transform hudParent, Vector3 startPosition, IDialog iDialog)
    {
        SetHUDParent(hudParent);
        transform.position = startPosition;
        _interactionController = new PlayerInteractionController(interactionDistance);
        (_input as PlayerInput).OnInteract += () => { _interactionController.Interactable?.Interact(this, iDialog); };
        _cameraController = new PlayerCameraController(PlayerCamera);
    }

    private void SetHUDParent(Transform mainCanvas)
    {
        if (_Hud != null)
        {
            if (mainCanvas != null)
                _Hud.transform.SetParent(mainCanvas);
        }

    }

    void Update()
    {
        _animationController.Update();
        _interactionController?.Update(transform, GetBodyDirection());
    }

    public Vector3 GetBodyDirection()
    {
        if (bodyBack.activeSelf)
            return Vector2.up;
        else if (bodyFront.activeSelf)
            return Vector2.down;
        else if (bodySide.activeSelf && bodySide.transform.rotation.y > 0)
            return Vector2.left;
        else
            return Vector2.right;
    }

    private void OnDrawGizmos()
    {
        if (bodyBack != null &&
            bodyFront != null &&
            bodySide != null)
        {
            if (_interactionController != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(_interactionController._startPosition, _interactionController._endPosition);
            }
        }
    }
}
