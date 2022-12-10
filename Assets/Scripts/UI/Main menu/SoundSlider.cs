using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    Slider thisSlider;

    private void OnEnable() => thisSlider = GetComponent<Slider>();

    public void ChangeSoundVolume(AudioMixerGroup selectMixerGroup) => 
        selectMixerGroup.audioMixer.SetFloat(selectMixerGroup.name, thisSlider.value - 80);
}