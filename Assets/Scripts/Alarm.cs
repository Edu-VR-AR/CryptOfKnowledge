using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _currentVolume = 0;
    private float _targetVolume;
    private float _maximumVolume = 1.0f;
    private float _minimumVolume = 0;
    private float _deltaOfVolume = 1.0f;
    private Coroutine _changeVolumeInWork;

    private void Start()
    {
        _changeVolumeInWork = StartCoroutine(ChangeVolume(_minimumVolume));
    }

    public void OnAlarm()
    {
        StopCoroutine(_changeVolumeInWork);
        _changeVolumeInWork = StartCoroutine(ChangeVolume(_maximumVolume));
    }

    public void OffAlarm()
    {
        StopCoroutine(_changeVolumeInWork);
        _changeVolumeInWork = StartCoroutine(ChangeVolume(_minimumVolume));
    }

    private IEnumerator ChangeVolume(float _targetVolume)
    {
        bool isWork = true;

        while (isWork)
        {
            _currentVolume = _alarm.volume;

            _alarm.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _deltaOfVolume * Time.deltaTime);

            yield return null;
        }
    }
}
