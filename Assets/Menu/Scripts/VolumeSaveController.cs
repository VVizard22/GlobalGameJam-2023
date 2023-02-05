using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using RoboRyanTron.Unite2017.Events;

namespace GGJ
{
    public class VolumeSaveController : MonoBehaviour
    {
        [SerializeField] GameEvent StartSong;
        [SerializeField] Slider volumeSlider = null;
        [SerializeField] AudioMixer _mixer;

        private void Awake()
        {
            LoadValues();
            StartSong.Raise();
        }

        public void saveVolumeButton()
        {
            float volumeValue = volumeSlider.value;
            PlayerPrefs.SetFloat("VolumeValue", volumeValue);
            LoadValues();

        }

        void LoadValues()
        {
            float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
            _mixer.SetFloat("Volume", volumeValue);
        }
    }

}
