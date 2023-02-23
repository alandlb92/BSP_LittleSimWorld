using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [Header("UI references to instantiate")]
    [SerializeField] private PlayerHUD PlayerHud_Reference;

    [Space]
    [Header("Interaction")]
    [SerializeField] private float interactionDistance;

    [Space]
    [Header("Physics")]
    [SerializeField] private float velocityMultiply;
    [SerializeField] private Rigidbody2D rBody;

    [Space]
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private InputBase _input;
    [SerializeField] private GameObject bodyFront;
    [SerializeField] private GameObject bodySide;
    [SerializeField] private GameObject bodyBack;

    [Space]
    [SerializeField] private CustomizableSpritesContainer _customizableSprites;



    private CharacterCustomizeController _customizeController;
    private CharacterAnimationController _animationController;
    private CharacterMovementController _movementController;
    private CharacterInventoryController _inventoryController;
    private PlayerInteractionController _interactionController;
    private PlayerHUD _Hud;

    public ICharacterInventory IInvetory => _inventoryController;
    public ICustomizeCharacter ICustomize => _customizeController;

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

        if (_input is PlayerInput)
        {
            _interactionController = new PlayerInteractionController(interactionDistance);
            (_input as PlayerInput).OnInteract += () => { _interactionController.Interactable?.Interact(this); };
        }
    }

    public void InitializePlayer(Transform hudParent, Vector3 startPosition)
    {
        SetHUDParent(hudParent);
        transform.position = startPosition;
    }

    private void SetHUDParent(Transform mainCanvas)
    {
        if (_Hud != null)
        {
            if (mainCanvas != null)
                _Hud.transform.parent = mainCanvas;
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
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + GetBodyDirection() * interactionDistance);
        }
    }
}
