using UnityEngine;
using UnityEngine.Events;

public class RoomSignalization : MonoBehaviour
{
    [SerializeField] private GameObject _alarmSource;
    [SerializeField] private UnityEvent _someoneInvaded;
    [SerializeField] private UnityEvent _everyoneLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _someoneInvaded?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _everyoneLeft?.Invoke();
        }
    }
}
