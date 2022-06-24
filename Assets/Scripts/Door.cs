using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{

    [SerializeField] private UnityEvent _someoneInvaded;
    [SerializeField] private UnityEvent _everyoneLeft;
    [SerializeField] private UnityEvent _RogueInvade;
    [SerializeField] private UnityEvent _RogueLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _RogueInvade?.Invoke();
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