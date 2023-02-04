using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        [SerializeField] SpriteRenderer music;
        [SerializeField] SpriteRenderer sounds;
        [SerializeField] SpriteRenderer back;


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
        [SerializeField] GameObject mainScreen;

        int screen;
        int settingsOption, settingsOptionBe;
        bool submit;
        float vertical, horizontal;
        float verticalTime, horizontalTime;
        void Awake()
        {
            screen = 1;
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
                            
                            Debug.Log(settingsOption);
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

        void musicAdjust()
        {
            
            for ( int i = 0 ; i < 11; i++ )
            {
                Debug.Log(musicPower);
                if (i <= musicPower) music_Spr[i].sprite = vol_On;
                else music_Spr[i].sprite = vol_Off;
                snd_Menu.volume = (musicPower / 10f);
            }
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
            settingsOption = op;
            if (op == 1) music.sprite = Music_On;
            if (op == 2) sounds.sprite = Sounds_On;
            if (op == 3) back.sprite = Back_On;
            if (settingsOptionBe == 1) music.sprite = Music_Off;
            if (settingsOptionBe == 2) sounds.sprite = Sounds_Off;
            if (settingsOptionBe == 3) back.sprite = Back_Off;
            settingsOptionBe = op;

        }

        void loadMainMenu()
        {
            screenMenu.SetActive(true);
            screenSettings.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonUp("Submit")) submit = false;
            if (vertical == 0) verticalTime = 0;
            if (horizontal == 0) horizontalTime = 0;
            if (screen == 1) settingsMenu();
        }
    }
}
