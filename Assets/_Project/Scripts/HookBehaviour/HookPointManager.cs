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

        [SerializeField] FloatReference _playerX;
        [SerializeField] FloatReference _playerY;

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
                    //Vector2 directionVector = new Vector2(_mouseX, _mouseY);
                    //Debug.DrawRay(new Vector3(_playerX,_playerY,0),-directionVector,Color.red,2);
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
