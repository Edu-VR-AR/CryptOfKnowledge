using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _someoneInvaded;
    [SerializeField] private UnityEvent _everyoneLeft;

    public event UnityAction RogueInvaded;
    public event UnityAction RogueLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            RogueInvaded?.Invoke();
        }

        _someoneInvaded?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            RogueLeft?.Invoke();
        }

        _everyoneLeft?.Invoke();
    }
}