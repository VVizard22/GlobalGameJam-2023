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
        RootBehaviour _assignedRoot;
        [SerializeField]
        public bool isAnchored { get; private set; } = false;
        [SerializeField]
        LayerMask _hookableLayer;
        
        public void AnchorPoint()
        {
            isAnchored = true;
            SendJoint.Raise();
        }
        public void MovePosition(float mouseX,float mouseY)
        {
            transform.position = new Vector3(mouseX,mouseY,0f);
            Vector3 rayStartPoint = transform.position;
            rayStartPoint.z += 1;
            Ray ray = new Ray(rayStartPoint, -Vector3.forward * 2);
            Debug.DrawRay(rayStartPoint,-Vector3.forward * 2, Color.red, 2);
            
            if(Physics2D.Raycast(rayStartPoint, -Vector3.forward * 2, Mathf.Infinity, _hookableLayer))
            {
                _assignedRoot.gameObject.SetActive(true);
                _assignedRoot.StartAnimation(transform.position);
                //StartCoroutine(BeginAnchorPoint());
                AnchorPoint();
            }else
            {
                DisableAnchor();
                DisableJoint();
            }
        }

        IEnumerator BeginAnchorPoint()
        {
            yield return null;
        }

        public void DisableJoint()
        {
            EndHook.Raise();
        }

        public void DisableAnchor()
        {
            _assignedRoot.gameObject.SetActive(false);
            isAnchored = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            /*
            GameObject current = collision.gameObject;
            print(current.tag);
            if (!current.CompareTag("Hookable"))
                return;

            AnchorPoint();
            */
        }
    }
}
