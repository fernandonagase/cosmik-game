using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _shootSfx = null;
    [SerializeField] private AudioSource _audioSource = null;

    public void PlayShoot()
    {
        _audioSource.PlayOneShot(_shootSfx);
    }
}
