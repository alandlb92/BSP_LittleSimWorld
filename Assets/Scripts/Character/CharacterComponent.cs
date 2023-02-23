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
    [SerializeField] private SpriteRenderer bodyFront;
    [SerializeField] private SpriteRenderer bodyLeft;
    [SerializeField] private SpriteRenderer bodyBack;
    [SerializeField] private SpriteRenderer hairFront;
    [SerializeField] private SpriteRenderer hairLeft;
    [SerializeField] private SpriteRenderer hairBack;
    [SerializeField] private SpriteRenderer faceFront;
    [SerializeField] private SpriteRenderer faceLeft;
    [SerializeField] private Animator animator;
    [SerializeField] private InputBase _input;

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
                _bodyLeft = bodyLeft,
                _rigidbody = rBody
            });

        if (PlayerHud_Reference)
            _Hud = Instantiate(PlayerHud_Reference);

        _customizeController = new CharacterCustomizeController(new CharacterCustomizeController.Configuration
        {
            _bodyBack = bodyBack,
            _bodyFront = bodyFront,
            _bodyLeft = bodyLeft,
            _hairBack = hairBack,
            _hairFront = hairFront,
            _hairLeft = hairLeft,
            _faceFront = faceFront,
            _faceLeft = faceLeft
        });

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
        if (bodyBack.enabled)
            return Vector2.up;
        else if (bodyFront.enabled)
            return Vector2.down;
        else if (bodyLeft.enabled && bodyLeft.flipX)
            return Vector2.left;
        else
            return Vector2.right;
    }

    private void OnDrawGizmos()
    {
        if (bodyBack != null &&
            bodyFront != null &&
            bodyLeft != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + GetBodyDirection() * interactionDistance);
        }
    }
}
