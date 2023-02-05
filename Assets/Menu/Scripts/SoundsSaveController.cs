using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace GGJ
{
    public class SoundsSaveController : MonoBehaviour

    {
        [SerializeField] Slider volumeSlider = null;
        [SerializeField] TMP_Text volumeTextUI = null;

        private void Awake()
        {
            LoadValues();
        }

        public void VolumeSlider(float volume)
        {
            volumeTextUI.text = volume.ToString("0.0");

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
            volumeSlider.value = soundValue;
            GameObject[] sounds = GameObject.FindGameObjectsWithTag("sounds");
            foreach (GameObject sound in sounds)
            {
                volumeSlider.value = soundValue;
                sound.GetComponent<AudioSource>().volume = soundValue;
            }
        }
    }

}
