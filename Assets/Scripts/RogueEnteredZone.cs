using UnityEngine;
using UnityEngine.Events;

public class RogueEnteredZone : MonoBehaviour
{
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
