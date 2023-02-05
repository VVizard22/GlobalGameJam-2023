using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace GGJ
{
    public class VolumeSaveController : MonoBehaviour
    {
        [SerializeField] Slider volumeSlider = null;
        [SerializeField] TMP_Text volumeTextUI = null;

        private void Awake()
        {
            LoadValues();
        }

        public void VolumeSlider (float volume)
        {
            volumeTextUI.text = volume.ToString("0.0");

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
            volumeSlider.value = volumeValue;
            GameObject[] sounds = GameObject.FindGameObjectsWithTag("music");
            foreach (GameObject sound in sounds)
            {
                volumeSlider.value = volumeValue;
                sound.GetComponent<AudioSource>().volume = volumeValue;
            }
        }
    }

}
