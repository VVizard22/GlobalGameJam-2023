using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GGJ
{
    public class CheckIfSamesong : MonoBehaviour
    {
        [SerializeField] AudioSource musicPlayer;
        public void CheckSong(AudioClip clip) 
        {
            if (clip == musicPlayer.clip)
                return;
            else
            {
                musicPlayer.clip = clip;
                musicPlayer.Play();
            }
            
        }
    }
}
