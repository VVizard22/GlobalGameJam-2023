using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ
{
    public class IntroScript : MonoBehaviour
    {
        [SerializeField] GameEvent audioStart;
        [SerializeField] GameEvent sceneEnd;

        public void RaiseAudioEvent() => audioStart.Raise();
        public void RaiseSceneEvent() => sceneEnd.Raise();
    }
}
