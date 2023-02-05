using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class ObjectMover : MonoBehaviour
    {
        [SerializeField] Transform _Target;
        [SerializeField] float multiplyer = 0.1f;
        [SerializeField]
        [Range(0f, 05f)]
        float _errorMargin = 2f;
        Vector3 _directionVector = Vector3.zero;

        bool shouldMove = true;

        public void SetShouldMove(bool should) => shouldMove = should;

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (!shouldMove)
                return;

            _directionVector = _Target.position - transform.position;
            _directionVector.Normalize();
            _directionVector *= multiplyer;

            if (Vector3.Distance(transform.position, _Target.position) <= _errorMargin)
                return;

            _directionVector.z = 0;
            transform.position += _directionVector;
        }

    }
}
