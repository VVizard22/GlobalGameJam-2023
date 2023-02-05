using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ.Utils
{
    public class UtilsInput : MonoBehaviour
    {
        [SerializeField]
        GameEvent PauseMenu;
        [SerializeField]
        GameEvent ResetLevel;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseMenu.Raise();

            if (Input.GetKeyDown(KeyCode.R))
                ResetLevel.Raise();
        }
    }
}
