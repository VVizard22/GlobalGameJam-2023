using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class SettingsController : MonoBehaviour
    {
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


        int settingsOption, settingsOptionBe;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
