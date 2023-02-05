using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;
namespace GGJ
{
    public class PauseMenuHandler : MonoBehaviour
    {
        public delegate void PauseMenu(bool shouldPause);
        public static PauseMenu OnPauseMenu;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameEvent PlaySong;
        private void Start()
        {
            PlaySong.Raise();
        }

        public void OnPauseMenuRaised()
        {
            bool currentActive = !pauseMenu.activeSelf;
            OnPauseMenu?.Invoke(!currentActive);
            pauseMenu.SetActive(currentActive);


        }
    }
}
