using UnityEngine;
public class InputBase : MonoBehaviour
{
    protected IMovement _iMovement;

    public void SetUp(IMovement movementController)
    {
        _iMovement = movementController;
    }
}
