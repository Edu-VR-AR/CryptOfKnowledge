using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Door : MonoBehaviour
{
    private Animator _doorAnimation;
    private string _nameBooleanState = "IsOpen";
    private AnimationPart _animationPart;

    private void Start()
    {
        _doorAnimation = GetComponent<Animator>();
        _animationPart = new AnimationPart(_doorAnimation, _nameBooleanState);
    }

    private void OnTriggerEnter(Collider other)
    {
        _animationPart.OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        _animationPart.CloseDoor();
    }   
}

public class AnimationPart
{
    private string _nameBooleanState;
    private Animator _doorAnimation;

    public AnimationPart(Animator doorAnimation, string nameBooleanState)
    {
        _nameBooleanState = nameBooleanState;
        _doorAnimation = doorAnimation;
    }

    public void OpenDoor()
    {
        _doorAnimation.SetBool(_nameBooleanState, true);
    }

    public void CloseDoor()
    {
        _doorAnimation.SetBool(_nameBooleanState, false);
    }
}