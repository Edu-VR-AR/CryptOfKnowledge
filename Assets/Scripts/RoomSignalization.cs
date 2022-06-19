using UnityEngine;
using UnityEngine.Events;

public class RoomSignalization : MonoBehaviour
{
    [SerializeField] private UnityEvent _someoneInvaded;
    [SerializeField] private UnityEvent _everyoneLeft;

    private bool _isRogueBehindDoor = false;
    private bool _isRogueGoInside = false;

    public void DetectRogueBehind()
    {
        _isRogueBehindDoor = !_isRogueBehindDoor;
        ActivateSignalization();
    }

    public void DetectRogueInside()
    {
        _isRogueGoInside = !_isRogueGoInside;
        ActivateSignalization();
    }

    private void ActivateSignalization()
    {
        if (_isRogueBehindDoor && _isRogueGoInside)
        {
            _someoneInvaded?.Invoke();
        }

        if (_isRogueBehindDoor && _isRogueGoInside == false)
        {
            _everyoneLeft?.Invoke();
        }
    }
}
