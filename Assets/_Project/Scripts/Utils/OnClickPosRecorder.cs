using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ.Utils
{
    public class OnClickPosRecorder : PositionRecorder
    {
        [Header("Event")]
        [SerializeField] [Tooltip("Event that raises whenever you try to hook")] 
        GameEvent StartEventToTrigger;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RecordPosition(mousePos.x, mousePos.y);
                StartEventToTrigger.Raise();
            }
        }
    }
}
