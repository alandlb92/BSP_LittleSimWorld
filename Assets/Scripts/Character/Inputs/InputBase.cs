using UnityEngine;
public class InputBase : MonoBehaviour
{
    protected IMovement _movementController;

    public void SetUp(IMovement movementController)
    {
        _movementController = movementController;
    }
}
