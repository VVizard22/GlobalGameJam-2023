using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


namespace GGJ
{
    public class SoundsSaveController : MonoBehaviour

    {
        [SerializeField] Slider volumeSlider = null;
        [SerializeField] AudioMixer _mixer;

        private void Awake()
        {
            LoadValues();
        }

        public void saveVolumeButton()
        {
            float soundValue = volumeSlider.value;
            PlayerPrefs.SetFloat("soundValue", soundValue);
            LoadValues();

        }

        void LoadValues()
        {
            float soundValue = PlayerPrefs.GetFloat("soundValue");
            _mixer.SetFloat("Volume",soundValue);
        }
    }

}
