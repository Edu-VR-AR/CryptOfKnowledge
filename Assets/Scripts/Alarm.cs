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

    public void OnAlarm()
    {
        _changeVolumeInWork = StartCoroutine(ChangeVolume());
        _alarm.Play();
    }

    public void OffAlarm()
    {
        _alarm.Stop();
        StopCoroutine(_changeVolumeInWork);
    }

    private IEnumerator ChangeVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            _currentVolume = _alarm.volume;

            if (_currentVolume == _minimumVolume)
            {
                _targetVolume = _maximumVolume;
            }
            else if (_currentVolume == _maximumVolume)
            {
                _targetVolume = _minimumVolume;
            }

            _alarm.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _deltaOfVolume * Time.deltaTime);

            yield return null;
        }
    }
}
