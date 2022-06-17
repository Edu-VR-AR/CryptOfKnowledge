using UnityEngine;

public class SignalizationActivator : MonoBehaviour
{
    private AudioSource audioSource;
    private float currentVolume;
    private float targetVolume;
    private float maximumVolume = 1.0f;
    private float minimumVolume = 0;
    private float deltaOfVolume = 1.0f;
    private bool isSoundUp = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    private void Update()
    {
        if (audioSource.isActiveAndEnabled)
        {
            currentVolume = audioSource.volume;

            if (isSoundUp == true)
            {
                targetVolume = maximumVolume;
            }
            else
            {
                targetVolume = minimumVolume;
            }

            audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, deltaOfVolume * Time.deltaTime);

            if (audioSource.volume == targetVolume)
            {
                isSoundUp = !isSoundUp;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            audioSource.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            audioSource.enabled = false;
        }
    }
}
