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
            
           
            settingsOption = settingsOptionBe= 1;
            adjustOptions();

        }
        void adjustOptions()
        {
            
            soundsAdjust();
        }
        void settingsMenu()
        {
            
                
                        
                       
                            
                       
                            
                            soundsAdjust();
                        
                    
                
                
                    
                    

            
        }

        void saveSettings()
        {
            PlayerPrefs.SetInt("musicPower", musicPower);
            PlayerPrefs.SetInt("soundsPower", soundsPower);
            PlayerPrefs.Save();
        }

      
       

        void soundsAdjust()
        {
            
           
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

        public void changeScreen()
        {
            screen = true;
        }
    }
}
