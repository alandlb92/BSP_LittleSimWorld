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
    [SerializeField] private Animator animator;
    [SerializeField] private InputBase _input;

    private CharacterAnimationController _animationController;
    private CharacterMovementController _movementController;
    private CharacterInventoryController _inventoryController;
    private PlayerInteractionController _interactionController;
    private PlayerHUD _Hud;

    public ICharacterInventory IInvetory => _inventoryController;

    private void Start()
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

        _inventoryController = new CharacterInventoryController(_Hud);

        _input?.SetUp(_movementController);

        if (_input is PlayerInput)
            _interactionController = new PlayerInteractionController(interactionDistance);

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
