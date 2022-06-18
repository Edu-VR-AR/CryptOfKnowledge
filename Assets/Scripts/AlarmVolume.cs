using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmVolume : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _currentVolume;
    private float _targetVolume;
    private float _maximumVolume = 1.0f;
    private float _minimumVolume = 0;
    private float _deltaOfVolume = 1.0f;
    private bool _isSoundUp = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_audioSource.isActiveAndEnabled)
        {
            _currentVolume = _audioSource.volume;

            if (_isSoundUp == true)
            {
                _targetVolume = _maximumVolume;
            }
            else
            {
                _targetVolume = _minimumVolume;
            }

            _audioSource.volume = Mathf.MoveTowards(_currentVolume, _targetVolume, _deltaOfVolume * Time.deltaTime);

            if (_audioSource.volume == _targetVolume)
            {
                _isSoundUp = !_isSoundUp;
            }
        }
    }
}
