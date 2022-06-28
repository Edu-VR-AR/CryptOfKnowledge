using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _someoneInvaded;
    [SerializeField] private UnityEvent _everyoneLeft;

    public static UnityAction _RogueInvaded;
    public static UnityAction _RogueLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _RogueInvaded?.Invoke();
        }

        _someoneInvaded?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _RogueLeft?.Invoke();
        }

        _everyoneLeft?.Invoke();
    }
}