using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _mixerParameter;

    private void Start()
    {
        if (PlayerPrefs.HasKey(this._mixerParameter))
        {
            this._mixer.SetFloat(this._mixerParameter, PlayerPrefs.GetFloat(this._mixerParameter));
        }
        else
        {
            this._mixer.SetFloat(_mixerParameter, 0);
        }
    }
    public void ChangeAudioLevel(float audioLevel)
    {
        this._mixer.SetFloat(_mixerParameter, audioLevel);
        PlayerPrefs.SetFloat(this._mixerParameter, audioLevel); //change mixer level and save it on playerprefs
    }
}
