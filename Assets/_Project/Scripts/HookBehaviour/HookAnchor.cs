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
        public bool isAnchored { get; private set; } = false;
        [SerializeField]
        GameObject _visualAid;
        
        public void AnchorPoint(float mouseX, float mouseY)
        {
            isAnchored = true;
            transform.position = new Vector3(mouseX, mouseY, 0f);
            _visualAid.SetActive(true);
            SendJoint.Raise();
        }

        public void DisableJoint()
        {
            SendJoint.Raise();
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
                DisableJoint();
                DisableAnchor();
            }
            Debug.Log("Test");
        }
    }
}
