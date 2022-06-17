using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator OpenCloseDoorAnimation;

    void Start()
    {
        OpenCloseDoorAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenCloseDoorAnimation.SetBool("IsOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        OpenCloseDoorAnimation.SetBool("IsOpen", false);
    }
}