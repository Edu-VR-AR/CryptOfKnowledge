using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimation;

    private readonly string _nameBooleanState = "IsOpen";

    public void OpenDoor()
    {
        _doorAnimation.SetBool(_nameBooleanState, true);
    }

    public void CloseDoor()
    {
        _doorAnimation.SetBool(_nameBooleanState, false);
    }
}
