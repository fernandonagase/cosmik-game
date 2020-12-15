using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer = null;

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("masterVol", value);
    }

    public void SetBgmVolume(float value)
    {
        mixer.SetFloat("bgmVol", value);
    }

    public void SetSfxVolume(float value)
    {
        mixer.SetFloat("sfxVol", value);
    }
}
