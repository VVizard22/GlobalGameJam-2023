using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;

namespace GGJ.Hooks
{
    public class HookPointManager : MonoBehaviour
    {
        [SerializeField] GameEvent _disableJointsEvent;
        [SerializeField] HookAnchor[] _anchors;

        [SerializeField] FloatReference _mouseX;
        [SerializeField] FloatReference _mouseY;

        int index = 0;
        public void SetAnchorPoint()
        {
            bool done = false;
            
            for (int i = 0; i < _anchors.Length && !done; i++)
            {
                HookAnchor anchor = _anchors[i];
                if (!anchor.isAnchored)
                {
                    done = true;
                    anchor.MovePosition(_mouseX, _mouseY);
                }
            }
            if (!done)
            {
                _anchors[index].MovePosition(_mouseX,_mouseY);
                index++;
                if (index >= _anchors.Length)
                    index = 0;
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _disableJointsEvent.Raise();
                foreach (HookAnchor hA in _anchors)
                {
                    hA.DisableJoint();
                    hA.DisableAnchor();
                    hA.MovePosition(0,0);
                }
            }
        }


    }
}
