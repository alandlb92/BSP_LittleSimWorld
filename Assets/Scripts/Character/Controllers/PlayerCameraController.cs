using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : IPlayerCamera
{
    private Camera _camera;

    public PlayerCameraController(Camera camera)
    {
        _camera = camera;
    }

    public void SetCameraDistance(float value)
    {
        _camera.orthographicSize = value;
    }
}
