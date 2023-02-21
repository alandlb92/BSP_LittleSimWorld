using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
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
    private void Start()
    {
        _movementController= new CharacterMovementController(rBody, velocityMultiply);
        _animationController = new CharacterAnimationController(
            new CharacterAnimationController.Configuration {
            _animator = animator,
            _bodyBack = bodyBack,
            _bodyFront = bodyFront,
            _bodyLeft = bodyLeft,
            _rigidbody = rBody
        });

        _input.SetUp(_movementController);
    }

    void Update()
    {
        _animationController.Update();
    }
}
