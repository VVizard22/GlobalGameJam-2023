using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ
{
    public class WinScript : MonoBehaviour
    {
        [SerializeField] GameEvent winSound;
        [SerializeField] GameEvent stopMusic;
        [SerializeField] GameEvent endTimerEvent;

        private void Start()
        {
            stopMusic.Raise();
            winSound.Raise();

            StartCoroutine(StartCountdown());
        }

        IEnumerator StartCountdown()
        {
            yield return new WaitForSeconds(3f);

            endTimerEvent.Raise();
        }

    }
}
