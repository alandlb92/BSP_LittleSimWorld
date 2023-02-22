using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputBase
{
    struct InputAxisVectorInfo
    {
        float x;
        float y;

        public void SetX(float x)
        {
            this.x = x;
        }

        public void SetY(float y)
        {
            this.y = y;
        }

        public Vector2 GetValue()
        {
            return Vector2.ClampMagnitude(new Vector2(x, y), 1);
        }
    }

    private InputAxisVectorInfo _inputAxis;

    public event Action OnInteract;

    public void Update()
    {
        SetInputInfo();
        _iMovement.Move(_inputAxis.GetValue());

        if(Input.GetButtonDown("Submit"))
        {
            OnInteract?.Invoke();
        }
    }

    private void SetInputInfo()
    {
        _inputAxis.SetX(Input.GetAxisRaw("Horizontal"));
        _inputAxis.SetY(Input.GetAxisRaw("Vertical"));
    }
}
