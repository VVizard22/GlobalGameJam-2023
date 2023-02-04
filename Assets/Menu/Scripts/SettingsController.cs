using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GGJ
{
    public class SettingsController : MonoBehaviour
    {
        [Header("General Options")]
        [SerializeField] int musicPower;
        [SerializeField] int soundsPower;
        [SerializeField] GameObject screenMenu;
        [SerializeField] GameObject screenSettings;
        [SerializeField] float timeOptions;


        [Header("Settings Elements")]
        [SerializeField] Image music;
        [SerializeField] Image sounds;
        [SerializeField] Image back;


        [Header("Settings Sprites")]
        [SerializeField] Sprite Music_Off;
        [SerializeField] Sprite Music_On;
        [SerializeField] Sprite Sounds_Off;
        [SerializeField] Sprite Sounds_On;
        [SerializeField] Sprite Back_Off;
        [SerializeField] Sprite Back_On;
        [SerializeField] Sprite vol_On;
        [SerializeField] Sprite vol_Off;
        [SerializeField] SpriteRenderer[] music_Spr;
        [SerializeField] SpriteRenderer[] sound_Spr;

        [Header("Sounds")]
        [SerializeField] AudioSource snd_Options;
        [SerializeField] AudioSource snd_Selection;
        [SerializeField] AudioSource snd_Menu;

        [Header("Scripts")]
        [SerializeField] GameObject mainScreenScripts;

        bool screen;
        int settingsOption, settingsOptionBe;
        bool submit;
        float vertical, horizontal;
        float verticalTime, horizontalTime;
        void Awake()
        {
            screen = true;
            loadSettings();
            verticalTime = horizontalTime = 0;
            settingsOption = settingsOptionBe= 1;
            adjustOptions();

        }
        void adjustOptions()
        {
            musicAdjust();
            soundsAdjust();
        }
        void settingsMenu()
        {
            {
                if (vertical != 0)
                {
                    if (verticalTime == 0 || verticalTime > timeOptions)
                    {
                        if (vertical == 1 && settingsOption > 1) settingsSelection(settingsOption - 1);
                        if (vertical == -1 && settingsOption < 3) settingsSelection(settingsOption + 1);
                        if (verticalTime > timeOptions) verticalTime = 0;
                        
                    }
                    verticalTime += Time.deltaTime;
                }
                if (horizontal == 0) horizontalTime = 0; else
                {
                    if((horizontalTime == 0 || horizontalTime > timeOptions) && (settingsOption == 1 || settingsOption == 2))
                    {
                        
                        
                        if (settingsOption == 1 && ((horizontal < 0 && musicPower > 0) || horizontal > 0 && musicPower < 10))
                        {
                            musicPower += (int)horizontal;
                            musicAdjust();
                        }
                        if (settingsOption == 2 && ((horizontal < 0 && soundsPower > 0) || horizontal > 0 && soundsPower < 10))
                        {
                            soundsPower += (int)horizontal;
                            soundsAdjust();
                        }
                    }
                    horizontalTime += Time.deltaTime;
                }

                
                if (Input.GetButtonDown("Submit") && !submit)
                {
                    
                    if (settingsOption == 3) loadMainMenu();

                }

            }
        }

        void saveSettings()
        {
            PlayerPrefs.SetInt("musicPower", musicPower);
            PlayerPrefs.SetInt("soundsPower", soundsPower);
            PlayerPrefs.Save();
        }

        void loadSettings()
        {
            musicPower = PlayerPrefs.GetInt("musicPower", 5);
            soundsPower = PlayerPrefs.GetInt("soundsPower", 5);
        }
        void musicAdjust()
        {
            for ( int i = 0 ; i < 11; i++ )
            {
                if (i <= musicPower) music_Spr[i].sprite = vol_On;
                else music_Spr[i].sprite = vol_Off;
            }
            Debug.Log(musicPower);
            snd_Menu.volume = (musicPower / 10f);
        }

        void soundsAdjust()
        {
            
            for (int i = 0; i < 11; i++)
            {
                if (i <= soundsPower) sound_Spr[i].sprite = vol_On;
                else sound_Spr[i].sprite = vol_Off;
            }
            GameObject[] sounds = GameObject.FindGameObjectsWithTag("sounds");
            snd_Selection.Play();
            foreach ( GameObject sound in sounds )
            {
                sound.GetComponent<AudioSource>().volume = (soundsPower/10f);
            }
        }

        void settingsSelection(int op)
        {
           
        }

        void loadMainMenu()
        {
           

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
