using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace GGJ.Hooks
{
    public class HookAnchor : MonoBehaviour
    {
        [SerializeField]
        GameEvent SendJoint;
        [SerializeField]
        GameEvent EndHook;
        [SerializeField]
        public bool isAnchored { get; private set; } = false;
        [SerializeField]
        GameObject _visualAid;

        bool canHook = false;
        
        public void AnchorPoint()
        {
            isAnchored = true;
            _visualAid.SetActive(true);
            SendJoint.Raise();
        }
        public void MovePosition(float mouseX,float mouseY)
        {
            transform.position = new Vector3(mouseX,mouseY,0f);
        }

        public void DisableJoint()
        {
            EndHook.Raise();
        }

        public void DisableAnchor()
        {
            _visualAid.SetActive(false);
            isAnchored = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject current = collision.gameObject;
            if (!current.CompareTag("Hookable"))
            {
                //DisableJoint();
                //DisableAnchor();
                return;
            }
            AnchorPoint();
        }
    }
}
