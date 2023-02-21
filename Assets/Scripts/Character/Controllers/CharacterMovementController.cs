using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController  : IMovement
{

    private Rigidbody2D _rBody;
    private float _velocityMultiply;

    public CharacterMovementController(Rigidbody2D rBody, float velocityMultiply)
    {
        _rBody = rBody;
        _velocityMultiply = velocityMultiply;
    }

    public void Move(Vector2 axis)
    {
        _rBody.velocity = axis * _velocityMultiply;
    }
}
